    public class Client
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Data clientData { get; set; }
    }
    
    public class Data
    {
        public int id { get; set;}
        public Dictionary<string, string> properties { get; set; }
        public Dictionary<string, int> subcategories { get; set; }
    }
