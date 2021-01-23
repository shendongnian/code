    public class ZoneMapping
    {
        [Key, Column(Order = 0)]
        public String PostcodeKey { get; set; }
        [Key, ForeignKey("Zone"), Column(Order = 1)]
        public int Zone_ID { get; set; }
        public Zone Zone { get; set; }
    }
