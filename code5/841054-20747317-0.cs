    var pNames = Process.GetProcesses()
                        .Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                        .OrderByDescending(x => x.PagedMemorySize64)
                        .Select(x => x.ProcessName);
    foreach (var name in pNames)
        listRam.Items.Add(name);
