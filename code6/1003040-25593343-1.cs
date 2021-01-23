    public class Albummatches
    {
        [JsonProperty("Album")]
        [JsonConverter(typeof(JsonAlbumConverter))]
        public List<Album> Albums { get; set; }
    }
