    public class ProcessedLog
    {
        [Key]
        public int Id { get; set; }
        // Some other data
        public virtual LogLocation Location { get; set; }
    }
