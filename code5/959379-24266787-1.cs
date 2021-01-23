    class DataFormat
    {
        [JsonProperty("errors")]
        public Object Errors { get; set; }
        [JsonProperty("data")]
        [JsonConverter(typeof(DataListConverter))]
        public List<Data> Data { get; set; }
    }
