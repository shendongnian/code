    public static Level GetLogLevel(this ILog log)
    {
         if (log.IsEnabledFor(Level.Debug)) { return Level.Debug; }
         else ....
    }
    public static void Log(this ILog log, Level level, ...)
    {
        switch(level) ....
    }
