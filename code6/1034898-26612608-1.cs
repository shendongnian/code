    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public int capacity { get; set; }
        public object url { get; set; }
        public List<object> avoidConcurrencyLocationIds { get; set; }
    }
