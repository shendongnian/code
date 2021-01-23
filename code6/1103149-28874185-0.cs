    internal class LogEntry
    {
        public LogEntry(DateTime dateTime, bool status)
        {
            DateTime = dateTime;
            Status = status;
        }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
    }
