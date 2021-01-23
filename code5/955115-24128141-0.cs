    Process[] processes = Process.GetProcesses();
    
    foreach (Process process in processes)
    {
        if (!string.IsNullOrEmpty(process.MainWindowTitle))
        {
            Console.WriteLine("Window title of {0} : {1}", process.ProcessName, process.MainWindowTitle);
        }
    }
