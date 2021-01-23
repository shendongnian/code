    public static int ExecuteBatchFile(string batchFilePath, int timeout, bool killOnTimeout = false)
    {
       using (var p = Process.Start(batchFilePath))
       {
           p.WaitForExit(timeout);
           if (p.HasExited)
               return p.ExitCode;
           if (killOnTimeout)
           {
               p.Kill();
           }
           else
           {
               p.CloseMainWindow();
           }
           throw new TimeoutException(string.Format("Time allotted for executing `{0}` has expired ({1} ms).", batchFilePath, timeout));
       }
    }
