    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace Office2013Version
    {
        public class VersionFinder
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr GetCurrentProcess();
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr GetModuleHandle(string moduleName);
            [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
            static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)]string procName);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);
            [DllImport("Advapi32.dll")]
            static extern uint RegOpenKeyEx(UIntPtr hKey, string lpSubKey, uint ulOptions, int samDesired, out int phkResult);
            [DllImport("Advapi32.dll")]
            static extern uint RegCloseKey(int hKey);
            [DllImport("advapi32.dll", EntryPoint = "RegQueryValueEx")]
            static extern int RegQueryValueEx(int hKey, string lpValueName, int lpReserved, ref uint lpType,
                System.Text.StringBuilder lpData, ref uint lpcbData);
            private static UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(0x80000002u);
            private static UIntPtr HKEY_CURRENT_USER = new UIntPtr(0x80000001u);
            private Dictionary<string, string> OfficeVersions = new Dictionary<string, string>();
            public VersionFinder()
            {
                OfficeVersions.Add("7.0", "Office97");
                OfficeVersions.Add("8.0", "Office98");
                OfficeVersions.Add("9.0", "Office2000");
                OfficeVersions.Add("10.0", "OfficeXP");
                OfficeVersions.Add("11.0", "Office2003");
                OfficeVersions.Add("12.0", "Office2007");
                OfficeVersions.Add("14.0", "Office2010");
                OfficeVersions.Add("15.0", "Office2013");
            }
            private string GetOfficeVersionNumber()
            {
                string OfficeVersionNo = null;
                bool Is64BitWindows = Is64BitOperatingSystem();
                if (!Is64BitWindows)
                {
                    OfficeVersionNo = GetOfficeVersionNumber("SOFTWARE\\Microsoft\\Office\\");
                }
                else
                {
                    OfficeVersionNo = GetOfficeVersionNumber("SOFTWARE\\Microsoft\\Office\\");
                    if (OfficeVersionNo == null)
                        OfficeVersionNo = GetOfficeVersionNumber("SOFTWARE\\Wow6432Node\\Microsoft\\Office\\");
                }
                return OfficeVersionNo;
            }
            private string GetOfficeVersionNumber(string RegistryPrefix)
            {
                string CurrentOfficeVersionNo = null;
                foreach (string OfficeVersionNo in OfficeVersions.Keys)
                {
                    string Path = GetRegKey64(HKEY_LOCAL_MACHINE, RegistryPrefix + OfficeVersionNo + "\\Excel\\InstallRoot", "Path");
                    if (Path != null)
                    {
                        CurrentOfficeVersionNo = OfficeVersionNo;
                        break;
                    }
                }
                return CurrentOfficeVersionNo;
            }
            public string GetOfficeVersion()
            {
                string OfficeVersionNo = GetOfficeVersionNumber();
                string InstalledOfficeVersion = OfficeVersions[OfficeVersionNo];
                bool Is64BitWindows = Is64BitOperatingSystem();
                if (!Is64BitWindows)
                {
                    //If windows is 32 bit, then office cannot be 64 bit
                    InstalledOfficeVersion += " (32 bit)";
                }
                else
                {
                    Nullable<bool> isOffice64Bit = IsOffice64Bit("SOFTWARE\\Microsoft\\Office\\", OfficeVersionNo);
                    if (isOffice64Bit == null)
                        isOffice64Bit = IsOffice64Bit("SOFTWARE\\Wow6432Node\\Microsoft\\Office\\", OfficeVersionNo);
                    if (isOffice64Bit.HasValue && isOffice64Bit.Value)
                        InstalledOfficeVersion += " (64 bit)";
                    else if (isOffice64Bit.HasValue && !isOffice64Bit.Value)
                        InstalledOfficeVersion += " (32 bit)";
                    else
                    {
                        InstalledOfficeVersion += " (Unknown bit)";
                    }
                }
                return InstalledOfficeVersion;
            }
            private bool Is64BitOperatingSystem()
            {
                if (IntPtr.Size == 8)
                {
                    //This size indicates that this is 64-bit programs
                    //and 64-bit programs can run only on Windows 64
                    return true;
                }
                else
                {
                    //This size indicates that this is 32-bit programs
                    //and 32-bit programs can run only on Windows 32 and 64
                    //Detect if current program is 32-bit, but running on Windows 64
                    bool flag;
                    return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") && IsWow64Process(GetCurrentProcess(), out flag)) && flag);
                }
            }
            private Nullable<bool> IsOffice64Bit(string RegistryPrefix, string OfficeVersionNo)
            {
                Nullable<bool> isOffice64Bit = null;
                string Bitness = GetRegKey64(HKEY_LOCAL_MACHINE, RegistryPrefix + OfficeVersionNo + "\\Outlook", "Bitness");
                if (Bitness == "x86")
                    isOffice64Bit = false;
                else if ((Bitness == "x64"))
                    isOffice64Bit = true;
                return isOffice64Bit;
            }
            private bool DoesWin32MethodExist(string moduleName, string methodName)
            {
                IntPtr moduleHandle = GetModuleHandle(moduleName);
                if (moduleHandle == IntPtr.Zero)
                {
                    return false;
                }
                return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
            }
            private string GetRegKey64(UIntPtr inHive, String inKeyName, String inPropertyName)
            {
                int hkey = 0;
                int in32or64key = 0x0100;
                int QueryValue = 0x0001;
                try
                {
                    uint lResult = RegOpenKeyEx(HKEY_LOCAL_MACHINE, inKeyName, 0, QueryValue | in32or64key, out hkey);
                    if (0 != lResult) return null;
                    uint lpType = 0;
                    uint lpcbData = 1024;
                    StringBuilder AgeBuffer = new StringBuilder(1024);
                    RegQueryValueEx(hkey, inPropertyName, 0, ref lpType, AgeBuffer, ref lpcbData);
                    string Age = AgeBuffer.ToString();
                    return Age;
                }
                finally
                {
                    if (0 != hkey) RegCloseKey(hkey);
                }
            }
        }
    }
    
