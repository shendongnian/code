    private static readonly Logger DefaultLogger = LogManager.GetLogger("Application");
    public static void Debug(Exception exception = null, string message = null, object data = null)
        => Write(DefaultLogger, LogLevel.Debug, message, exception, data);
    private static void Write(
        Logger logger,
        LogLevel level,
        string message = null,
        Exception exception = null, 
        object data = null)
    {
        var eventInfo = new LogEventInfo()
        {
            Level = level,
            Message = message,
            Exception = exception,
            Parameters = new[] { data, tag }
        };
        if (data != null) eventInfo.Properties["data"] = data.ToJson();
        eventInfo.Properties["level"] = eventInfo.GetLevelCode(); // custom level to int conversion
        logger.Log(eventInfo);
    }
