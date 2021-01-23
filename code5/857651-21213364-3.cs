    class VtulDb
    {
        private static readonly string CONNECTION_STRING;
        static VtulDb
        {
            // this code is only invoked on first use
            RegistryKey hklm =
                RegistryKey.OpenBaseKey(
                    RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey branch = hklm.OpenSubKey(@"SOFTWARE\Tulpep\Vtul");
            // store string
            CONNECTION_STRING = branch.GetValue("DBConnectionString").ToString();
        }
    }
