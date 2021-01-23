    public class PodcastGenreInfo
    {
        [JsonProperty("name")]
        public string GenreName { get; set; }
        [JsonProperty("subgenres")]
        public Dictionary<string, PodcastGenreInfo> Subgenres { get; set; }
    }
