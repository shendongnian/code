    Mutex globalWait = new Mutex();
    if (globalWait.WaitOne())
    {
       try
       {
          if (IsFileLocked(myFile)) return;
          // ... process file here ...
       }
       finally
       {
          globalWait.ReleaseMutex();
       }
    }
