    public class Response
    {
        [JsonProperty(PropertyName = "response")]
        Item[] Items { get; set; }
    }
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
