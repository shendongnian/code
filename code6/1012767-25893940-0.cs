    public class LogEntry
    {
        public int delay { get; set; }
    }
    public static LogEntry readLogEntryFromLine(string line)
    {
        return new LogEntry() {delay = Int32.Parse(line)};
    }
