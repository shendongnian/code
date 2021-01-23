    // I tested with notepad so you would switch this with the Microsoft Word exe name.
    string processName = "notepad";
    Process[] processes = Process.GetProcessesByName(processName);
    foreach (Process process in processes)
    {
        TimeSpan runningTime = DateTime.Now - process.StartTime;
        if (runningTime.TotalMinutes > 2)
            process.Kill();
    }
