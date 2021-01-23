    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
        public class NativeMethods {
            public static void SetFilePointer(SafeFileHandle hFile, long dist, SeekOrigin method) {
                int lodist = (int)dist;
                int hidist = (int)(dist >> 32);
                int retval = SetFilePointer(hFile, lodist, ref hidist, method);
                if (retval == -1) throw new System.ComponentModel.Win32Exception();
            }
    
            [DllImport("Kernel32.dll", SetLastError = true)]
            private static extern int SetFilePointer(SafeFileHandle hFile, 
                int distlo, ref int disthi, SeekOrigin method);
    
        }
    }
