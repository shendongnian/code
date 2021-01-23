    public static bool KillProcess(string name)
    {
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.StartsWith(name))
            {
                clsProcess.Kill();
                return true;
            }
        }
        return false;
    }
