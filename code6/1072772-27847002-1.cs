    private static IAppender CreateFileAppender(string name, string fileName)
    {
        PatternLayout patternLayout = new PatternLayout();
        patternLayout.ConversionPattern = "%date %level %logger: %message%newline";
        patternLayout.ActivateOptions();
        RollingFileAppender appender = new RollingFileAppender();
        appender.Name = name;
        appender.File = fileName;
        appender.AppendToFile = true;
        appender.MaxSizeRollBackups = 2;
        appender.RollingStyle = RollingFileAppender.RollingMode.Size;
        appender.MaximumFileSize = "10MB";
        appender.Layout = patternLayout;
        appender.LockingModel = new FileAppender.MinimalLock();
        appender.StaticLogFileName = true;
        appender.ActivateOptions();
        return appender;
    }
