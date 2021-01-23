    public class Segment
    {
        [Key]
        public int ID { get; set; }
        public uint segNum { get; set; }
        public string segRepair { get; set; }
        public virtual ICollection<Note> segNotes { get; set; }
    }
