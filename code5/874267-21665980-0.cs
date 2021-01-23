    // GetWindowsVersion: Fetch Winver info from specified file
    public static string GetWindowsFileVersion()
    {
        String codeBaseUri =
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        String codeBase =
            new Uri(codeBaseUri).LocalPath;
        System.Diagnostics.FileVersionInfo info = FileVersionInfo.GetVersionInfo(codeBase);
        return info.FileVersion.ToString();
    }
