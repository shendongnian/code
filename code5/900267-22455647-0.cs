    public class MyCustomResponse 
    {
        [JsonProperty(PropertyName = "data")]   
        public object Data { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }
    }
