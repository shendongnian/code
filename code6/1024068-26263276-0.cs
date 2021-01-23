    public class Race
    {
        public int id { get; set; }
        public int mask { get; set; }
        public string side { get; set; }
        public string name { get; set; }
    }
    
    public class RootObject
    {
        public List<Race> races { get; set; }
    }
