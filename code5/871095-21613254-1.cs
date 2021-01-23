    class LogFacade
    {
      public string AppName {get; private set;}
    
      LogFacade(string appName)
      {
        AppName = appName;
      }
    
      public void Write(string msg) 
      {
        AppLog.Write(string.format("[{0}]{1}", AppName, msg));
      }
    }
