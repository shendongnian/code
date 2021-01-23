    public class Datum2
    {
        public string source { get; set; }
        public string id { get; set; }
        public string created_time { get; set; }
    }
    
    public class Photos
    {
        public List<Datum2> data { get; set; }
    }
    
    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string created_time { get; set; }
        public Photos photos { get; set; }
    }
    
    public class Albums
    {
        public List<Datum> data { get; set; }
    }
    
    public class Datum3
    {
        public string id { get; set; }
        public string message { get; set; }
        public string picture { get; set; }
        public string link { get; set; }
        public string object_id { get; set; }
        public string type { get; set; }
        public string created_time { get; set; }
    }
    
    public class Feed
    {
        public List<Datum3> data { get; set; }
    }
    
    public class RootObject
    {
        public Albums albums { get; set; }
        public Feed feed { get; set; }
        public string id { get; set; }
    }
