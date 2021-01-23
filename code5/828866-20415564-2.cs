    foreach (Process clsProcess in Process.GetProcesses())
    {
        if (clsProcess.ProcessName.StartsWith("iexplore"))
        {
            clsProcess.Kill();                
        }
    }
