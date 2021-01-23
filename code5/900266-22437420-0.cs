    public class Response
    {
        public Dictionary<string, Data> data { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
    
    public class Data
    {
        public int id { get; set; }
        public string title { get; set; }
    }
