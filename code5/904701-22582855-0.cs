    public class GiveItAName
    {
        [JsonProperty("chunks")]
        public List<string> Chunks { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("interest")]
        public string Interest { get; set; }
        [JsonProperty("interest_id")]
        public int InterestId { get; set; }
        [JsonProperty("main_image")]
        public string MainImage { get; set; }
        [JsonProperty("published_at")]
        public long PublishedAt { get; set; }
        [JsonProperty("publisher_id")]
        public int PublisherId { get; set; }
        [JsonProperty("publisher_name")]
        public string PublisherName { get; set; }
        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
