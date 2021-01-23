        List<Process> lstProcs = new List<Process>();
        lstProcs = ProcessHandler.WhoIsLocking(file);
    
        foreach (Process p in lstProcs)
        {
            if (p.MachineName == ".")
                ProcessHandler.localProcessKill(p.ProcessName);
            else
                ProcessHandler.remoteProcessKill(p.MachineName, txtUserName, txtPassword, p.ProcessName);
        }
