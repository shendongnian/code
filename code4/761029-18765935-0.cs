        [ComRegisterFunction]
        static void ComRegister(Type t)
        {
            string keyName = @"CLSID\" + t.GUID.ToString("B");
            using (RegistryKey key =
                Registry.ClassesRoot.OpenSubKey(keyName, true))
            {
                key.CreateSubKey("Control").Close();
                using (RegistryKey subkey = key.CreateSubKey("MiscStatus"))
                {
                    // 131456 decimal == 0x20180.
                    long val = (long)
                        (OLEMISC.OLEMISC_INSIDEOUT
                        | OLEMISC.OLEMISC_ACTIVATEWHENVISIBLE
                        | OLEMISC.OLEMISC_SETCLIENTSITEFIRST);
                    subkey.SetValue("", val);
                }
                using (RegistryKey subkey = key.CreateSubKey("TypeLib"))
                {
                    Guid libid =
                        Marshal.GetTypeLibGuidForAssembly(t.Assembly);
                    subkey.SetValue("", libid.ToString("B"));
                }
                using (RegistryKey subkey = key.CreateSubKey("Version"))
                {
                    Version ver = t.Assembly.GetName().Version;
                    string version =
                      string.Format("{0}.{1}", ver.Major, ver.Minor);
                    subkey.SetValue("", version);
                }
            }
        }
