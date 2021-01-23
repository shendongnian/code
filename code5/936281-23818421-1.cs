    public class ZoneMapping
    {
        [Key, Order(0)]
        public String PostcodeKey { get; set; }
        [Key, ForeignKey("Zone"), Order(1)]
        public int Zone_ID { get; set; }
        public Zone Zone { get; set; }
    }
