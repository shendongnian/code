    private static string GetLastUserLoggedOn(string machineName)
    {
        string location = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI";
        var registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
        using (var hive = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName, registryView))
        {
            using (var key = hive.OpenSubKey(location))
            {
                var item = key.GetValue("LastLoggedOnUser");
                string itemValue = item == null ? "No Logon Found" : item.ToString();
                return itemValue;
            }
        }
    }
