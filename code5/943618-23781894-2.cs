    public static class ILogExtensions
    {
          private static readonly List<Level> logLevels = new List<Level>
          {
              Level.Alert,
                … // etc
          }
          public static IEnumerable<Level> EnabledLogLevels(this ILog logger)
          {
               return logLevels.Where(level => logger.Logger.IsEnabledFor(level));
          }
    {
