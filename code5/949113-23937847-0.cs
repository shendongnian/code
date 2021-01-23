    public class Gift  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GiftCategory> Categories { get; set; } // is this incorrect???
        public int Rating { get; set; }
    }
    public class GiftCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Gift> Gifts { get; set; }
    }
