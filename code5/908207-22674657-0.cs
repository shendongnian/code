    public class Meeting
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name{ get; set; }
        [JsonProperty(PropertyName = "calledby")]
        public bool Calledby{ get; set; }
    }
