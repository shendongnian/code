    public class Competitor
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    
        [JsonProperty("team")]
        public string Team { get; set; }
    
        [JsonProperty("outcomeDateTime")]
        public string OutcomeDateTime { get; set; }
    }
