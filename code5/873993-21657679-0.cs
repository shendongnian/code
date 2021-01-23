    private static string GetProcessInstanceName(int pid)
    { 
        string name = String.Empty;
        Process proc = System.Diagnostics.Process.GetProcessById(pid);
        if(proc != null)
        {
            name = proc.ProcessName;
        }
        return name;
    }
