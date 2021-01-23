    [JsonConverter(typeof(ViewConverter))]
    public class View
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public Object ElementData { get; set; }
    }
