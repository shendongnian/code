    LogEntry logEntry3 = new LogEntry()
    {
        Message = "Oops!",
        Severity = System.Diagnostics.TraceEventType.Error
    };
    logEntry3.Categories.Add("General");
    var extendedProperties = new Dictionary<string, object>();
    extendedProperties.Add("PaddedSeverity", logEntry3.Severity.ToString().PadRight(11));
    logEntry3.ExtendedProperties = extendedProperties;
    logger.Write(logEntry3);
