    Process[] allProcesses = Process.GetProcesses();
    foreach (Process workingProcess in allProcesses)
    {
        if (workingProcess.MainWindowTitle.Length > 0)
        {
            Console.WriteLine(workingProcess.MainWindowTitle);
        }
    }
