    public class InnerObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string  Username { get; set; }
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("revisionDate")]
        public string RevisionDate { get; set; }
    }
