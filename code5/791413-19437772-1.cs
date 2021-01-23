    private RegistryKey GetUninstallRegistryKeyByProductName(string productName)
    {
            var subKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            if (subKey == null)
                return null;
            foreach (var name in subKey.GetSubKeyNames())
            {
                var application = subKey.OpenSubKey(name, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.QueryValues | RegistryRights.ReadKey | RegistryRights.SetValue);
                if (application == null)
                    continue;
                foreach (var appKey in application.GetValueNames().Where(appKey => appKey.Equals("DisplayName")))
                {
                    if (application.GetValue(appKey).Equals(productName))
                        return application;
                    break;
                }
            }
            return null;
        }
