﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2016 Realm Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
////////////////////////////////////////////////////////////////////////////
 
using System;
using System.Diagnostics;

namespace Realms
{
    
    /// <summary>
    /// Per-platform utility functions. A copy of this file exists in each platform project such as Realm.Win32.
    /// </summary>
    internal static class InteropConfig
    {
        public static bool Is64Bit
        {
#if REALM_32       
            get {
                Debug.Assert(IntPtr.Size == 4);
                return false;
            }
#elif REALM_64
            get {
                Debug.Assert(IntPtr.Size == 8);
                return true;
            }
#else
            //if this is evaluated every time, a faster way could be implemented. Size is cost when we are running though so perhaps it gets inlined by the JITter
            get { return (IntPtr.Size == 8); }
#endif
        }


#if (DEBUG)
        private const string BuildName = "Debug";
#else
        private const string BuildName = "Release";
#endif

#if REALM_32
        public const string DLL_NAME = "wrappersx86-" + BuildName;
#elif REALM_64
        public const string DLL_NAME = "wrappersx64-" + BuildName;
#else
        public const string DLL_NAME = "** error see InteropConfig.cs DLL_NAME";
#endif
    }
}