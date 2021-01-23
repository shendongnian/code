    process.Start();
    Thread.Sleep(2000);
    while(getNumProcesses() > 0)
       process.WaitForExit();
    private static int getNumProcesses()
    {
        Process[] myProcesses = Process.GetProcessesByName("mstsc");
        return myProcesses.Length;
    }
