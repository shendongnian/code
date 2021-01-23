    public class LogModel
    {
        public string LogMessage { get; set; }
        public string PartitionKey { get;set;}
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string ETag { get; set; }
    }
