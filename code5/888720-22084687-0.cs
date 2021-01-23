    void CheckProcessThread()
    {
       while (checkProcesses)
       {
          counter = System.Diagnostics.Process.GetProcessesByName("MyProc").Length;
          Thread.Sleep(1000);
       }
    }
