    var localByName = Process.GetProcesses()
                             .Where(p => p.ProcessName.Contains("explor"));
    foreach (Process p in localByName)
    {
        p.Kill();
    }
