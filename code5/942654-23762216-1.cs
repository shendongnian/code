    public sealed class Data
    {
        [JsonProperty("siteBaseHostAddress")]
        public string SiteBaseHostAddress { get; internal set; }
        [JsonProperty("id")]
        public string Id { get; internal set; }
        [JsonProperty("titleEncodedFancy")]
        public string TitleEncodedFancy { get; internal set; }
        [JsonProperty("bodySummary")]
        public string BodySummary { get; internal set; }
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; internal set; }
        [JsonProperty("lastActivityDate")]
        [JsonConverter(typeof (EpochTimeConverter))]
        public DateTime LastActivityDate { get; internal set; }
        [JsonProperty("url")]
        [JsonConverter(typeof (UriConverter))]
        public Uri QuestionUrl { get; internal set; }
        [JsonProperty("ownerUrl")]
        [JsonConverter(typeof (UriConverter))]
        public Uri OwnerUrl { get; internal set; }
        [JsonProperty("ownerDisplayName")]
        public string OwnerDisplayName { get; internal set; }
        [JsonProperty("apiSiteParameter")]
        public string ApiSiteParameter { get; internal set; }
    }
