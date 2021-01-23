    private string CheckJreJdkVersion()
    {
        StringBuilder sb = new StringBuilder();
    
        string jre = @"SOFTWARE\JavaSoft\Java Runtime Environment";
        string jdk = @"SOFTWARE\JavaSoft\Java Development Kit";
        string jreInstallDirValueName = "INSTALLDIR";
        string jdkInstallDirValueName = "JavaHome";
        // Check 32-bit JRE
        GetJreJdkVersion(jre, RegistryView.Registry32, jreInstallDirValueName, ref sb, "JRE", "32");
        // Check 64-bit JRE
        GetJreJdkVersion(jre, RegistryView.Registry64, jreInstallDirValueName, ref sb, "JRE", "64");
        // Check 32-bit JDK
        GetJreJdkVersion(jdk, RegistryView.Registry32, jdkInstallDirValueName, ref sb, "JDK", "32");
        // Check 64-bit JDK
        GetJreJdkVersion(jdk, RegistryView.Registry64, jdkInstallDirValueName, ref sb, "JDK", "64");
    
        string res = sb.ToString();
        return res;
    }
    
    private void GetJreJdkVersion(string jreJdkPath, RegistryView registryView, string jreJdkInstallDirValueName, ref StringBuilder sb, string jreJdk, string bitVer)
    {
        RegistryKey key = GetRegistryKeyHKLM(jreJdkPath, registryView);
        if (key == null)
            return;
    
        List<string> lstVersions = new List<string>();
        foreach (var version in key.GetSubKeyNames())
        {
            lstVersions.Add(version);
        }
    
        IEnumerable<string> relevantVersions = GetRelevantVersions(lstVersions);
    
        foreach (var relevantVersion in relevantVersions)
        {
            string regPath = string.Empty;
            if (jreJdk == "JRE")
            {
                regPath = Path.Combine(jreJdkPath, Path.Combine(relevantVersion, "MSI"));
            }
            else
            {
                regPath = Path.Combine(jreJdkPath, relevantVersion);
            }
    
            string installDir = GetRegistryValueHKLM(regPath, jreJdkInstallDirValueName, registryView);
    
            sb.Append("Detected " + bitVer + "-bit " + jreJdk + ", install directory: " + installDir + "\n");
        }
    }
    
    private IEnumerable<string> GetRelevantVersions(List<string> lstVersions)
    {
        IEnumerable<string> versions = lstVersions.Where(version => version.Contains("_"));
    
        return versions;
    }
    
    public RegistryKey GetRegistryKeyHKLM(string keyPath, RegistryView view)
    {
        RegistryKey localMachineRegistry
            = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view);
    
        return string.IsNullOrEmpty(keyPath)
            ? localMachineRegistry
            : localMachineRegistry.OpenSubKey(keyPath);
    }
    
    public string GetRegistryValueHKLM(string keyPath, string keyName, RegistryView view)
    {
        RegistryKey registry = GetRegistryKeyHKLM(keyPath, view);
        if (registry == null) return null;
    
        string value = string.Empty;
        try
        {
            value = registry.GetValue(keyName).ToString();
        }
        catch (Exception)
        {
    
        }
        return value;
    }
