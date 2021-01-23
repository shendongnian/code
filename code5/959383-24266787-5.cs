    class DataFormat
    {
        [JsonProperty("errors")]
        public Dictionary<string, object> Errors { get; set; }
        [JsonProperty("data")]
        [JsonConverter(typeof(DataListConverter))]
        public List<Data> Data { get; set; }
    }
