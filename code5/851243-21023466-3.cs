    public static ILog GetSample(string arg)
    {
        var logger = new DynamicLogger(arg);
        logger.Level = Level.All;
        var consoleAppender = new ConsoleAppender();
        consoleAppender.Name = arg;
        consoleAppender.Layout = new PatternLayout(arg + ": %m%newline");
        logger.AddAppender(consoleAppender);
        var newLog = new LogImpl(logger);
        if (_logs.Any(log => log.Logger.Name == newLog.Logger.Name) == false)
            _logs.Add(newLog);
        return newLog;
    }
