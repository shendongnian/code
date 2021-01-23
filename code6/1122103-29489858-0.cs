    internal static bool GetIsCompatibleIEVersionInstalled(int minimumRequiredVersion)
    {
        var compatibleIEVersionInstalled = false;
        var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer");
        var fullVersion = (string)key.GetValue("Version");
        int majorVersion;
        if (int.TryParse(fullVersion.Split('.').First(), out majorVersion))
        {
            compatibleIEVersionInstalled = majorVersion >= minimumRequiredVersion;
        }
        return compatibleIEVersionInstalled;
    }
