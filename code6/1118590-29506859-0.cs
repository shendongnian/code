    /// <summary>
    /// Check application is running by the name of its process ("processName").
    /// </summary>
    static bool IsProcessOpen(string processName)
    {
        foreach (Processing.Process clsProcess in Processing.Process.GetProcesses())
        {
            if (clsProcess.ProcessName.ToUpper().Contains(processName.ToUpper()))
                    return true;
        }
        return false;
    }
