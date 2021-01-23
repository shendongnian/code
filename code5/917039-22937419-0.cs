    public static void StartStorageEmulator()
    {
        //var count = Process.GetProcessesByName("DSServiceLDB").Length;
        //if (count == 0)
        //	ExecuteCSRun("/devstore:start");
        var count = Process.GetProcessesByName("WAStorageEmulator").Length;
        if (count == 0)
            ExecuteWAStorageEmulator("start");
    }
    /*
    private static void ExecuteCSRun(string argument)
    {
        var start = new ProcessStartInfo
        {
            Arguments = argument,
            FileName = @"c:\Program Files\Microsoft SDKs\Windows Azure\Emulator\csrun.exe"
        };
    var exitCode = ExecuteProcess(start);
    Assert.AreEqual(exitCode, 0, "Error {0} executing {1} {2}", exitCode, start.FileName, start.Arguments);
    }
    */
    private static void ExecuteWAStorageEmulator(string argument)
    {
        var start = new ProcessStartInfo
        {
            Arguments = argument,
            FileName = @"c:\Program Files (x86)\Microsoft SDKs\Windows Azure\Storage Emulator\WAStorageEmulator.exe"
        };
        var exitCode = ExecuteProcess(start);
        Assert.AreEqual(exitCode, 0, "Error {0} executing {1} {2}", exitCode, start.FileName, start.Arguments);
    }
    private static int ExecuteProcess(ProcessStartInfo start)
    {
        int exitCode;
        using (var proc = new Process { StartInfo = start })
        {
            proc.Start();
            proc.WaitForExit();
            exitCode = proc.ExitCode;
        }
        return exitCode;
    }
