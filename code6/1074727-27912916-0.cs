    var runningProcess = System.Diagnostics.Process.GetProcessesByName("chrome");
    if (runningProcess.Length != 0)
    {
        System.Diagnostics.Process.Start("chrome", filename);
    }
    runningProcess = System.Diagnostics.Process.GetProcessesByName("firefox");
    if (runningProcess.Length != 0)
    {
        System.Diagnostics.Process.Start("firefox", filename);
    }
    runningProcess = System.Diagnostics.Process.GetProcessesByName("iexplore");
    if (runningProcess.Length != 0)
    {
        System.Diagnostics.Process.Start("iexplore", filename);
    }
