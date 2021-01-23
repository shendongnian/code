    public class Contact
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("organization")]
        public string Organization { get; set; }
        
        [JsonProperty("full_address")]
        public string FullAddress { get; set; }
        etc.
    }
