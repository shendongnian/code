    public static class Tools
    {
        // Delegate for new log entries
        public delegate void LogEntryAddedDelegate(string message);
        public static LogEntryAddedDelegate LogEntryAdded { get; set; }
        public static void AddToLogger(string msg)
        {
            // Do some stuff here
            // Call the event
            LogEntryAdded(msg);
        }
    }
