    public sealed class Response
    {
        [JsonProperty("action")]
        public string Action { get; internal set; }
        [JsonProperty("data")]
        [JsonConverter(typeof (DataConverter))]
        public Data Data { get; internal set; }
    }
