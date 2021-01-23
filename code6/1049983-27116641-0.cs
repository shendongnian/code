    public class ItemCollection
    {
        [JsonProperty(PropertyName = "entries")]
        public IEnumerable<BoxFile> Entries { get; internal set; }
    }
