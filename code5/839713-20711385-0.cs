    public class LogItem : KeyedEntityBase
    {
        public LogItem(string message, string description, string status)
            : this()
        {
            Message = message;
            Description = description;
            Status = status;
        }
        private LogItem() { }
    
        internal LogItem(string message, string description, string status, DateTime dateTme)
            : this(message, description, status)
        {
            OccuredOn = dateTime;
        }
    
        public DateTime OccurredOn { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
