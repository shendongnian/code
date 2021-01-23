    [JsonConverter(typeof(LinkSerializer))]
    public class Link
    {
        [JsonConstructor]
        public Link(int id)
        {
            Id = id;
        }
        [JsonIgnore]
        public int Id { get; internal set; }
        [JsonProperty("title")]
        public string Title { get; internal set; }
        [JsonProperty("description")]
        public string Description { get; internal set; }
        public Avatar AuthorAvatar { get; internal set; }
    }
    public class Avatar
    {
        [JsonProperty("author_avatar")]
        public string DefaultImageUri { get; internal set; }
        [JsonProperty("author_avatar_small")]
        public string SmallImageUri { get; internal set; }
        [JsonProperty("author_avatar_medium")]
        public string MediumImageUri { get; internal set; }
    }
