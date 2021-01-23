    public class Data
    {
        public string mode { get; set; }
        [JsonProperty("data")]
        public Dictionary<int, CustomerInfo> customers { get; set; }
    }
