    public class WorkOrder
    {
        [Key]
        public string woNum { get; set; }
        public string woClosingStatus { get; set; }
        
        public virtual ICollection<Note> woNotes { get; set; }
        public string machSN { get; set; }
        [ForeignKey("machSN")]
        public virtual Machine woMachine { get; set; }
        
        public virtual ICollection<Segment> woSegments { get; set; }
    }
