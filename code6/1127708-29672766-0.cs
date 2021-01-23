    class YourType
    {
        [JsonProperty("took")]
        public int Took { get; set; }
        [JsonProperty("timed_out")]
        public bool TimedOut { get; set; }
        [JsonProperty("_shards")]
        public Shard  Shards { get; set; }
        // and so on and so on
    }
    class Shard
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        
        [JsonProperty("successful")]
        public int SuccessFul { get; set; }
        [JsonProperty("failed")]
        public int Failed { get; set; }
    }
