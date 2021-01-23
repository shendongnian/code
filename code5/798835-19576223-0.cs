    public class Response
    {
        [JsonProperty("data")]
        public Dictionary<string, ItemContainer> { get; set; }
    }
    public class ItemContainer
    {
        [JsonProperty("Item")]
        public Item Item { get; set; }
    }
