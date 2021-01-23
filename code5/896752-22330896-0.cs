    RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
        RegistryView.Registry32);
    rk = rk.OpenSubKey(@"SOFTWARE\AVAST Software\Avast");
    string installPath = null;
    if (rk != null)
    {
        installPath = rk.GetValue("ProgramFolder", null);
    }
    if (installPath != null)
    {
        .... // Avast registry setting found
    }
