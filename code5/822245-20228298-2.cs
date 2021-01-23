    public static Process GetExplorerProcess()
    {
        var all = Process.GetProcessesByName("explorer");
        Process process = null;
        foreach (var p in all)
            if (process == null || p.StartTime > process.StartTime)
                process = p;
        return process;
    }
