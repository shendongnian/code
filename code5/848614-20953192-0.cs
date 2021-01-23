    public class Request
    {
        public string request { get; set; }
        public IDictionary<string,string> parameters { get; set; }
        public string pid { get; set; }
    }
    var request = JsonConvert.DeserializeObject<Request>(data);
