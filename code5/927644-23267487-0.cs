    public class Scheduling
    {
        public DateTime date { get; set; }
        public string description { get; set; }
    }
    
    public class RootObject
    {
        public string to { get; set; }
        public Scheduling scheduling { get; set; }
        public string id { get; set; }
    }
