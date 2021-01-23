<!-- -->
    public class Movie 
    {
        [JsonProperty("title")]
        [JsonConverter(typeof(SingleOrEnumerableJsonConverter<List<string>>))]
        public List<string> Title { get; set; }
        
        [JsonProperty("images")]
        [JsonConverter(typeof(SingleOrEnumerableJsonConverter<List<Image>>))]
        public List<Image> Images { get; set; }
        
        [JsonProperty("actors")]
        [JsonConverter(typeof(SingleOrEnumerableJsonConverter<List<Actor>>))]
        public List<Actor> Actors { get; set; }
        
        [JsonProperty("directors")]
        [JsonConverter(typeof(SingleOrEnumerableJsonConverter<List<Director>>))]
        public List<Director> Directors { get; set; }    
    }
