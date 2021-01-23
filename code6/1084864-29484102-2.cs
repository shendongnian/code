    public class LogLocation
    {
        [Key]
        public int Id { get; set; }
        // Some other data
        public virtual QueuedLog QueuedLog { get; set; }
        public virtual ProcessedLog ProcessedLog { get; set; }
    }
