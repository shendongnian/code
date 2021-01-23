    var sessionProcessIds = new HashSet<int>(dev.AudioSessionManager2.Sessions
                                                .AsEnumerable()
                                                .Select(x => x.GetProcessId)
                                                .Where(pid => pid != 0));
    var processes = Process.GetProcesses();
    var sessionProcessNames = processes.Where(p => sessionProcessIds.Contains(p.Id))
                                       .Select(p => p.ProcessName);
