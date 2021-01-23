    public class Usage
    {
        public string app { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> KVPs { get; set; }
    }
