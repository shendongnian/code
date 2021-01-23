    public static class Logger
    {
        public static event EventHandler<LogEntryEventArgs> EntryWritten;
    
        public static void AppendText(string text)
        {
            var tmp = EntryWritten;
            if (tmp != null)
                tmp(null, new LogEntryEventArgs(text));
        }
    }
    
    consumer:
    
    Logger.EntryWritten += Logger_OnEntryWritten;
    
    void Logger_OnEntryWritten(object sender, LogEntryEventArgs args)
    {
        _rtb.AppendText(args.Message);
        _rtb.AppendText(Environment.NewLine);
    }
