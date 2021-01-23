    public class MyLog4NetWrapper
    {
      ILog log;
    
      public MyLog4NetWrapper(string loggerName)
      {
        log = LogManager.GetLogger(loggerName)
      }
      public MyLog4NetWrapper(type loggerType)
      {
        log = LogManager.GetLogger(loggerType)
      }
      public void Info(string message) 
      { 
        if (log.IsInfoEnabled) log.Logger.Log(typeof(MyLog4NetWrapper), LogLevel.Info, message, null);
      }
      //Defer expensive calculations unless logging is enabled - thanks Grhm for the example
      public void Info(Func<string> formattingCallback )
      {
        if(log.IsInfoEnabled)
        {
          log.Logger.Log(typeof(MyLog4NetWrapper), LogLevel.Info, formattingCallback(), null);
        }
      }
      //Debug, Warn, Trace, etc are left as an exercise.
    }
