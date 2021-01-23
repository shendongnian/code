    public static int ExecuteBatchFile(string batchFilePath, int timeOut, bool killOnTimeOut)
    {
       using (var p = Process.Start(batchFilePath))
       {
           p.WaitForExit(timeOut);
           if (p.HasExited)
               return p.ExitCode;
           if (killOnTimeOut)
           {
               p.Kill();
           }
           else
           {
               p.CloseMainWindow();
           }
           throw new TimeoutException(string.Format("Time allotted for executing `{0}` has expired ({1} ms).", batchFilePath, timeOut));
       }
    }
