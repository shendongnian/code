    string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
    {
        RegistryKey subkey = null;
        try
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                subkey = key.OpenSubKey(subkey_name);
            string[] columns = subkey.GetValueNames();
            string appname = subkey.GetValue("DisplayName") as string;
            string Vendor_Publisher = Convert.ToString(subkey.GetValue("Publisher"));
            string Version = Convert.ToString(subkey.GetValue("DisplayVersion"));
            if (columns.Contains("InstallDate"))
            {
                string InstallDate = Convert.ToString(subkey.GetValue("InstallDate"));
            }
        }
     }
    catch (Exception ex)
     {
        throw ex;
     }
    }
