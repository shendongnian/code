    public class Property
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public Player Owner { get; set; }
        public bool IsOwned { get { return Owner != null; } }
    }
