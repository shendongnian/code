    private object lockObj = new object();
    private static void DoLClick()
    {
      if(!Monitor.TryEnter(lockObj, 0))
        return; // Just do nothing if we're busy.
      try
      {
        mouseCommand mc = new mouseCommand();
        mc.leftClick(Mouse.GetState().X,Mouse.GetState().Y));
      }
      finally
      {
        Monitor.Exit(lockObj);
      }
    }
    private void checkMouse()
    {
        Thread oThread = new Thread(DoLClick);
        oThread.Start();
    }
