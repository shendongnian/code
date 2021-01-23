    public class TestSerialization
    {
        [JsonProperty(PropertyName = "field_one")]
        public string ItemOne { get; set; }
    
        [JsonProperty(PropertyName = "field_two")]
        public string ItemTwo { get; set; }
    }
