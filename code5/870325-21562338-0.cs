    M4()
    {
      _event.Reset();
      try
        //reconnect
      finally
        _event.Set();
    }
    
    M1,2,3()
    {
      _event.WaitOne();
      //do actions
    }
