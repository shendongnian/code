    private static readonly Lazy<string> CONNECTION_STRING =
        new Lazy<string>(() =>
        {
            // this code is only invoked on first use
            RegistryKey hklm =
                RegistryKey.OpenBaseKey(
                    RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey branch = hklm.OpenSubKey(@"SOFTWARE\Tulpep\Vtul");
            return branch.GetValue("DBConnectionString").ToString();
        });
    private static string ConnectionString
    {
        get { return CONNECTION_STRING.Value; }
    }
