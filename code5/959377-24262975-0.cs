    class DataFormat
    {
        [JsonProperty("errors")]
        public Object Errors { get; set; }
    
        ...
    
        [JsonProperty("data")]
        public List<List<object>> Data { get; set; }    
    }
