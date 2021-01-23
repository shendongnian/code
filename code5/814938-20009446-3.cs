    void OnStart()
    {
      _mainThread = SynchronizationContext.Current();
    }
    
    void DoWork()
    {
      try
      {
        // Do the stuff...
      }
      catch (Exception e)
      {
        _mainThread.Post(() => Throw);
      }
    }
