    public int ExecuteBatchFile(string batchFilePath, int timeOut)
    {
        using (var p = Process.Start(batchFilePath))
        {
             p.WaitForExit(timeOut);
        
             if (p.HasExited)
                return p.ExitCode;
             throw new TimeOutException(string.format("Time allotted for executing `{0}` has expired ({1} ms).", batchFilePath, timeOut);
        }
    }
