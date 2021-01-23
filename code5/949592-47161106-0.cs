    public delegate void LogDelegate(string message, params object[] args);
    public LogDelegate this[string mode]
    {
        get
        {
            return (message, args) => LogIndexer(mode, message, args); 
        }
    }
