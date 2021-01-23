    BasicConfigurator.Configure();
    var appender = LogManager.GetRepository()
                             .GetAppenders()
                             .OfType<ConsoleAppender>()
                             .First();
    appender.Layout = new PatternLayout(your_pattern); // provide pattern
    ILog logger = LogManager.GetLogger(logger_name); // obtain logger
