    void DoWork()
    {
      try
      {
        // Do the stuff...
      }
      catch (Exception e)
      {
        LogException(e);
        this.Stop();
      }
    }
