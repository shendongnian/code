    internal class MoneyAmount
    {
        public float USD { get; set; }
    }
    internal class PropertyPrice
    {
    
        [JsonProperty("sharedMinPrice")]
        public MoneyAmount sharedMinPrice { get; set; }
    
        [JsonProperty("sharedAveragePrice")]
        public MoneyAmount sharedAveragePrice { get; set; }
    
        [JsonProperty("privateMinPrice")]
        public MoneyAmount privateMinPrice { get; set; }
    
        [JsonProperty("privateAveragePrice")]
        public MoneyAmount privateAveragePrice { get; set; }
    
        [JsonProperty("minPrice")]
        public MoneyAmount minPrice { get; set; }
    
        [JsonProperty("averagePrice")]
        public MoneyAmount averagePrice { get; set; }
    }
