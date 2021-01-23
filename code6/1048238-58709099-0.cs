	public class Response
    {
        [JsonProperty("ns1.model")]
		[JsonConverter(typeof(SafeCollectionConverter))]
        public List<Model> Model { get; set; }
    }
    public class Model
    {
        [JsonProperty("@mh")]
        public string Mh { get; set; }
        [JsonProperty("ns1.attribute")]
        public ModelAttribute Attribute { get; set; }
    }
    public class ModelAttribute
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        [JsonProperty("$")]
        public string Value { get; set; }
    }
