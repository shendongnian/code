    public class CompressedLogResponseBase
    {
        public string LoggerType { get; set; }
        public int NumberOfRegisters { get; set; }
        public int NewLogId { get; set; }
        public DateTime LoggerAnnounceTime { get; set; }
    }
    public class CompressedLogResponse : CompressedLogResponseBase
    {
        public List<Log> Log{ get; set; }
    }
