    public static void Log(this ILog log, Level level,
                           string message, bool sendEmail = true)
    { …
     if (sendEmail)
      { 
          //only to mail
          log = LogManager.GetLogger("MyMailAppender");
          log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, level, message, null);
      }
    }
