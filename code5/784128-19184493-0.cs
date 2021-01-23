    class Result
    {
        [JsonProperty("result")]
        public Dictionary<string, Car> Cars { get; set; }
    }
    class Car
    {
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
