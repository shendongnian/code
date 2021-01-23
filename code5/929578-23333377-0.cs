    //first of all lets make classes for your Shop and Basket:
    public class Basket
    {
        public List<Shop> Items = new List<Shop>();
    }
    public class Shop
    {
        public String photo { get; set; }
        public String breed { get; set; }
        public String name { get; set; }
        public String age_value  // for serialization
        {
            get { return age.ToString("D"); }
            set { age = DateTime.Parse(value); }
        }
        public double price { get; set; }
        [XmlIgnore]
        public DateTime age { get; set; }
    }
