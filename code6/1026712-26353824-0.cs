    public class Result
    {
        public string loc_name { get; set; }
        public string id { get; set; }
        public string href { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> results { get; set; }
    }
