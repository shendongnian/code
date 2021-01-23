    public class Trust
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
    }
    
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrustId { get; set; }
        public Trust Trust { get; set; }
    }
