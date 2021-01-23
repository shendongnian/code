    public class Response
    {
        public string id { get; set; }
        public string status { get; set; }
        public string datesubmitted { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> fields { get; set; }
    }
