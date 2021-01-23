    private static List<AppDetails> GetInstalledApps()
    {
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        List<AppDetails> apps = new List<AppDetails>();
        using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                {
                    AppDetails appInfo = new AppDetails(); //HERE
                    appInfo.appName = (string)subkey.GetValue("DisplayName");
                    appInfo.publisher = (string)subkey.GetValue("Publisher");
                    appInfo.appVersion = (string)subkey.GetValue("DisplayVersion");
                    if (appInfo.appName != null)
                    {
                        apps.Add(appInfo);
                    }
                }
            }
        }
        return apps;
    }
