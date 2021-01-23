    //get the 64-bit view first
    RegistryKey key = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
    key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            
    if (key == null)
    {
        //we couldn't find the value in the 64-bit view so grab the 32-bit view
        key = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
        key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
    }
    if (key != null)
    {
        Int64 value = Convert.ToInt64(key.GetValue("InstallDate").ToString());
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
        DateTime installDate = epoch.AddSeconds(value);
    }
