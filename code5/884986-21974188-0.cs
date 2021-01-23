    public class MyClass
    {
        public string email { get; set; }
        public long timestamp { get; set; }
        [JsonProperty("smtp-id")]
        public string smtpid { get; set; }
        public string category { get; set; }
        [JsonProperty("event")]
        public string evt { get; set; }
    }
