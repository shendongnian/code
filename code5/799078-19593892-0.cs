    class Wrapper
    {
        [JsonProperty("JsonValues")]
        public ValueSet ValueSet { get; set; }
    }
    
    class ValueSet
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("values")]
        public Dictionary<string, Value> Values { get; set; }
    }
    
    class Value
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("diaplayName")]
        public string DisplayName { get; set; }
    }
