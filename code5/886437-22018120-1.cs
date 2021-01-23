    public class SubscriberGet
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    
        [JsonProperty("data")]
        public List<DataFM> Data { get; set; }
    }
    
    public class DataFM
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    
        [JsonProperty("custom_fields")]
        public List<CustomField> custom_fields { get; set; }
    
        [JsonProperty("state")]
        public string State { get; set; }
    }
    public class CustomField
    {
        [JsonProperty("field")]
    	public string field { get; set; }
        [JsonProperty("value")]
    	public string value { get; set; }
    }
