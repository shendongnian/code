    public static event EventHandler<string> LogLineAdded = delegate { };
    public static void addToLog(string addition)
    {
        string logLine = addition + "\r\n";
        log += logLine;
        LogLineAdded(null, logLine);
    }
