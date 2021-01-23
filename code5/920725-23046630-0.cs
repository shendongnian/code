    public class Doupload
    {
        public string result { get; set; }
        public string key { get; set; }
    }
    
    public class Response
    {
        public string action { get; set; }
        public Doupload doupload { get; set; }
        public string server { get; set; }
        public string result { get; set; }
        public string current_api_version { get; set; }
    }
    public class RootObject
    {
        public Response response { get; set; }
    }
