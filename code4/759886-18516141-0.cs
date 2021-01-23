    public class Response
    {
        public Response()
        {
            Data = new List<KeyValuePair<string, string>>();
            Beta = new List<KeyValuePair<string, string>>();
        }
    
        public string Status { get; set; }
        public List<KeyValuePair<string, string>> Data { get; set; }
        public List<KeyValuePair<string, string>> Beta { get; set; }
    }
