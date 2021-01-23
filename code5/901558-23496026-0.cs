    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Text;
    using Microsoft.Win32;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                List<string> software = GetInstalledSoftware();
                // some entries will be duplicated!!!
            }
        public static List<string> GetInstalledSoftware()
        {
            const string KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            List<string> list = new List<string>();
            list.AddRange(GetInstalledSoftwareFromHive(RegistryHive.LocalMachine, KEY, false));
            list.AddRange(GetInstalledSoftwareFromHive(RegistryHive.LocalMachine, KEY, true));
            list.AddRange(GetInstalledSoftwareFromHive(RegistryHive.CurrentUser, KEY, false));
            list.AddRange(GetInstalledSoftwareFromHive(RegistryHive.CurrentUser, KEY, true));
            
            return list;
        }
        private static List<string> GetInstalledSoftwareFromHive(RegistryHive hive, string keyAddress, bool use64)
        {
            uint main = 0;
            List<string> list = new List<string>();
            try
            {
                uint err = Win32Registry.RegOpenKeyEx(unchecked((uint)hive), keyAddress, 0,
                    Win32Registry.RegSAM.Read | Win32Registry.RegSAM.EnumerateSubKeys | (use64 ? Win32Registry.RegSAM.WOW64_64Key : Win32Registry.RegSAM.WOW64_32Key),
                    out main);
                if (err != 0) throw new Exception();
                string[] names = GetSubkeysNames(main);
                if (names == null) throw new Exception();
                foreach (string subkeyName in names)
                {
                    uint sub = 0;
                    try
                    {
                        err = Win32Registry.RegOpenKeyEx(main, subkeyName, 0, Win32Registry.RegSAM.Read, out sub);
                        if (err != 0) continue;                        
                        string name = GetValueAsString(sub, "DisplayName");
                        if (name == null) continue;
                        list.Add(name);
                    }
                    finally
                    {
                        if (sub != 0)
                            Win32Registry.RegCloseKey(sub);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (main != 0)
                    Win32Registry.RegCloseKey(main);
            }
            return list;
        }
        internal static string[] GetSubkeysNames(uint hMainKey)
        {
            uint numSubKeys;
            uint errorCode = Win32Registry.RegQueryInfoKey(hMainKey, null, 0, 0, out numSubKeys, 0, 0, 0, 0, 0, 0, 0);
            if (errorCode != 0) return null;
            string[] names = new string[numSubKeys];
            for (uint i = 0; i < numSubKeys; i++)
            {
                uint maxKeySize = 1024;
                StringBuilder sb = new StringBuilder((int)maxKeySize);
                long writeTime;
                errorCode = Win32Registry.RegEnumKeyEx(hMainKey, i, sb, ref maxKeySize, 0, 0, 0, out writeTime);
                if (errorCode != 0) break;
                names[i] = sb.ToString();
            }
            return names;
        }
        internal static string GetValueAsString(uint hSubkey, string valueName)
        {
            RegistryValueKind subkeyKind = RegistryValueKind.String;
            StringBuilder subkeyValueText = new StringBuilder((int)1024);
            uint subKeyValueSize = (uint)subkeyValueText.Capacity;
            uint errorCode = Win32Registry.RegQueryValueEx(hSubkey, valueName, 0, ref subkeyKind, subkeyValueText, ref subKeyValueSize);
            if (errorCode != 0) return null;
            return subkeyValueText.ToString();
        }
        internal static class Win32Registry
        {
            internal const uint REG_BINARY = 3;
            internal const uint REG_SZ = 1;
            internal const uint REG_DWORD = 4;
            [Flags]
            public enum RegOption
            {
                NonVolatile = 0x0,
                Volatile = 0x1,
                CreateLink = 0x2,
                BackupRestore = 0x4,
                OpenLink = 0x8
            }
            [Flags]
            public enum RegSAM : uint
            {
                QueryValue = 0x0001,
                SetValue = 0x0002,
                CreateSubKey = 0x0004,
                EnumerateSubKeys = 0x0008,
                Notify = 0x0010,
                CreateLink = 0x0020,
                WOW64_32Key = 0x0200,
                WOW64_64Key = 0x0100,
                WOW64_Res = 0x0300,
                StandardRightsRead = 0x00020000,
                Read = 0x00020019,
                Write = 0x00020006,
                Execute = 0x00020019,
                AllAccess = 0x000f003f
            }
            [StructLayout(LayoutKind.Sequential)]
            public class SECURITY_ATTRIBUTES
            {
                public int nLength;
                public IntPtr lpSecurityDescriptor;
                public int bInheritHandle;
            }
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegCloseKey(
                uint hKey);
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegCreateKeyEx(
                uint hKey,
                string lpSubKey,
                int Reserved,
                string lpClass,
                RegOption dwOptions,
                RegSAM samDesired,
                SECURITY_ATTRIBUTES lpSecurityAttributes,
                out uint phkResult,
                IntPtr lpdwDisposition);
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegQueryValueEx(
                uint kHey,
                string lpValueName,
                int lpReserved,
                ref Microsoft.Win32.RegistryValueKind lpType,
                StringBuilder lpData,
                ref uint lpcbData
            );
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegQueryValueEx(
                uint kHey,
                string lpValueName,
                int lpReserved,
                ref Microsoft.Win32.RegistryValueKind lpType,
                ref uint lpData,
                ref uint lpcbData
            );
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegSetValueEx(
                uint hKey,
                string lpValueName,
                uint Reserved,
                uint dwType,
                [param: MarshalAs(UnmanagedType.LPArray)] byte[] lpData,
                uint cbData);
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegDeleteValue(
                uint hKey,
                string lpValueName);
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegDeleteKey(
                uint hKey,
                string lpSubKey);
            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern uint RegOpenKeyEx(
                uint hKey,
                string lpSubKey,
                uint ulOptions,
                RegSAM samDesired,
                out uint phkResult);
            [DllImport("advapi32.dll", EntryPoint = "RegEnumKeyEx")]
            internal extern static uint RegEnumKeyEx(uint hkey,
                uint index,
                StringBuilder lpName,
                ref uint lpcbName,
                uint reserved,
                uint lpClass,
                uint lpcbClass,
                out long lpftLastWriteTime);
            [DllImport("advapi32.dll", EntryPoint = "RegQueryInfoKey", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            internal extern static uint RegQueryInfoKey(
                uint hkey,
                StringBuilder lpClass,
                uint lpcbClass,
                uint lpReserved,
                out uint lpcSubKeys,
                uint lpcbMaxSubKeyLen,
                uint lpcbMaxClassLen,
                uint lpcValues,
                uint lpcbMaxValueNameLen,
                uint lpcbMaxValueLen,
                uint lpcbSecurityDescriptor,
                uint lpftLastWriteTime);
        }
    }
    }
