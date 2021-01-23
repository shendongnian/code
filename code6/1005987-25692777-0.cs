    public string get_regValue(string userroot, string subkey, string keyname, string app)
    {
        string userRoot = userroot;
        string subKey = subkey;
        string keyName = userRoot + "\\" + subKey;
        string regValue = (string)Registry.GetValue(keyName, keyname, null);
        regValue = regValue + app;
        return regValue;
    }
    private void DirectoryExporter_Click(object sender, EventArgs e)
    {
        // Button to Launch the Directory Exporter
        string regKey;
        RegistryKey openKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Dell");
        // Checks for key, if null (empty) get 32 bit key
        
        if (openKey == null)
        {
            // 32 bit key
            regKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Dell";
        }
        else
        {
            // 64 bit key
            regKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Dell";                
        }
        var regvalue = get_regValue(regKey, "Migrator for GroupWise", "AdminInstallDir", "gwdirapp.exe");
        Process.Start(regvalue);
