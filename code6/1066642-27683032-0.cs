    Process[] processes = Process.GetProcessesByName("TabTip");
    foreach (Process process in processes)
    {
        process.Kill();
    }
