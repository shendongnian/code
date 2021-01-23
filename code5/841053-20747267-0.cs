    var RAM = Process.GetProcesses();
    var procs = RAM.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                   .OrderByDescending(x => x.PrivateMemorySize64)
                   .ToList();
    foreach (var p in procs)
    {
        listRAM.Items.Add(p.ProcessName);
    }
