    public static void AddToLog(this IReader logObject, iqBeaconLogType logType, string message)
    {
        ILog log = LogManager.GetLogger(typeof(IReader));
        ...
    }
