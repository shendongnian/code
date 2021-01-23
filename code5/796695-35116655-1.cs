    private static void RegisteredWaitCallback(object state, bool timedOut)
    {
      Socket me = (Socket)state;
      // Interlocked to avoid a race condition with DoBeginConnect
      if (Interlocked.Exchange(ref me.m_RegisteredWait, null) != null)
      {
        switch (me.m_BlockEventBits)
        {
        case AsyncEventBits.FdConnect:
          me.ConnectCallback();
          break;
        case AsyncEventBits.FdAccept:
          me.AcceptCallback(null);
          break;
        }
      }
    }
    
