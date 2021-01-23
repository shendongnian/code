    private static void WebBrowserVersionEmulation()
    {
        const string BROWSER_EMULATION_KEY = 
        @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        //
        // app.exe and app.vshost.exe
        String appname = Process.GetCurrentProcess().ProcessName + ".exe";
        //
        // Internet Explorer 11. Webpages are displayed in IE11 edge mode, regardless of the !DOCTYPE directive.
        const int browserEmulationMode = 11001;
        RegistryKey browserEmulationKey =
            Registry.CurrentUser.OpenSubKey(BROWSER_EMULATION_KEY,RegistryKeyPermissionCheck.ReadWriteSubTree) ??
            Registry.CurrentUser.CreateSubKey(BROWSER_EMULATION_KEY);
        if (browserEmulationKey != null)
        {
            browserEmulationKey.SetValue(appname, browserEmulationMode, RegistryValueKind.DWord);
            browserEmulationKey.Close();
        }
    }
