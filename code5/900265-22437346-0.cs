    public class MyResponse {
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }
    
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
