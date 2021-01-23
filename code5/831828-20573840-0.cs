    using log4net;
    
    namespace Helpers 
    {
      public class MyObject {}
      public static class LoggerExtensions 
      {
        public static void Debug(this ILog log, MyObject obj, string format, params object[] arguments) 
        {
          if (!log.IsDebugEnabled) return;
          log.Logger.Log(typeof(LoggerExtensions), LogLevel.Debug, string.Format(format, arguments));
        }
      }
    }
