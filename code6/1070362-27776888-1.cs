        try
        {
          Process[] processlist = Process.GetProcesses();
          foreach (Process theprocess in processlist)
          {
            if (theprocess.ProcessName == "osk")
            {
              theprocess.Kill();
            }
          }
        }
        catch (Exception ex)
        {
          WriteLog("Error: KillKeyBoardProcess", ex);
        }
