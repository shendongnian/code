    TryScanSubKey(Registry.ClassesRoot);
    TryScanSubKey(Registry.LocalMachine.OpenSubKey("SOFTWARE"));
    TryScanSubKey(Registry.CurrentUser.OpenSubKey("SOFTWARE"));
    if (Is64BitOS)
    {
        TryScanSubKey(Registry.ClassesRoot.OpenSubKey("Wow6432Node"));
        TryScanSubKey(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node"));
        TryScanSubKey(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Wow6432Node"));
    }
