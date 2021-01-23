    public static IEnumerable<string> GetActiveMainWindowsTitle(string processName)
    {
        var ps = Process.GetProcessesByName(processName);
        foreach (var p in ps)
            yield return p.MainWindowTitle;
    }
