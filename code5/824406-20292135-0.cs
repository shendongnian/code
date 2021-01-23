    public class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "original_title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "credits")]
        public Credits Credits { get; set; }
    }
