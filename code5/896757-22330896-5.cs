    RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
        RegistryView.Registry64);
    rk = rk.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Antimalware");
    string installPath = null;
    if (rk != null)
    {
        installPath = rk.GetValue("InstallLocation", null);
    }
    if (installPath != null)
    {
        .... // Avast registry setting found
    }
