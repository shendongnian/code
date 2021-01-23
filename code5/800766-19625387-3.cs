    public class leg
    {
        public int Id { get; set; }
        public int tripId { get; set; }
        public virtual trip trip { get; set; }
    
        public int busId { get; set; }
        public virtual bus bus { get; set; }
    }
