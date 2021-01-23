    Process[] processList = Process.GetProcesses();
    List<string> windowTitles = new List<string>();
    foreach (Process proc in processList)
    {
        StringBuilder Buff = new StringBuilder(256);
        if (GetWindowText(proc.MainWindowHandle.ToInt32(), Buff, 256) > 0 )
        {
            windowTitles.Add(Buff.ToString());
        }
    }
