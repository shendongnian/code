    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        internal static class NativeMethods
        {
            public const int ERROR_SUCCESS = 0;
    
            public const uint HKEY_LOCAL_MACHINE = 0x80000002;
    
            public const int KEY_READ = 0x20019;
    
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
            public static extern int RegOpenKeyEx(
                UIntPtr hKey,
                string subKey,
                int ulOptions,
                int samDesired,
                out UIntPtr hkResult
            );
    
            [DllImport("advapi32.dll")]
            public static extern int RegCloseKey(
                UIntPtr hKey
            );
    
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
            public static extern int RegQueryValueEx(
                UIntPtr hKey,
                string lpValueName,
                int lpReserved,
                IntPtr type,
                IntPtr lpData,
                ref int lpcbData
            );
        }
    
        internal static class RegistryWrapper
        {
            private static void checkErrorCode(int errorCode)
            {
                if (errorCode != NativeMethods.ERROR_SUCCESS)
                    throw new Win32Exception(errorCode);
            }
    
            public static string ReadRegString(UIntPtr rootKey, string subKey, string name)
            {
                UIntPtr hkey;
                checkErrorCode(NativeMethods.RegOpenKeyEx(rootKey, subKey, 0, NativeMethods.KEY_READ, out hkey));
                try
                {
                    int cbData = 0;
                    checkErrorCode(NativeMethods.RegQueryValueEx(hkey, name, 0, IntPtr.Zero, IntPtr.Zero, ref cbData));
                    IntPtr ptr = Marshal.AllocHGlobal(cbData);
                    try
                    {
                        checkErrorCode(NativeMethods.RegQueryValueEx(hkey, name, 0, IntPtr.Zero, ptr, ref cbData));
                        return Marshal.PtrToStringUni(ptr, cbData / sizeof(char));
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(ptr);
                    }
                }
                finally
                {
                    checkErrorCode(NativeMethods.RegCloseKey(hkey));
                }
            }
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(RegistryWrapper.ReadRegString((UIntPtr)NativeMethods.HKEY_LOCAL_MACHINE, @"HARDWARE\DEVICEMAP\SERIALCOMM", @"\Device\Serial0"));
            }
        }
    }
