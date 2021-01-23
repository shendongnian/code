    [JsonObject]
    public class Wrapper
    {
        [JsonProperty(PropertyName = "ns1.model-response-list")]
        public ModelResponseList ModelResponseList { get; set; }
    }
    [JsonObject]
    public class ModelResponseList
    {
        [JsonProperty(PropertyName = "@throttle")]
        public int Throttle { get; set; }
        [JsonProperty(PropertyName = "@total-models")]
        public int TotalModels { get; set; }
        [JsonProperty(PropertyName = "ns1.model-responses")]
        public Responses ModelResponses { get; set; }
        [JsonProperty(PropertyName = "ns1.link")]
        public Link Link { get; set; }
    }
    [JsonObject]
    public class Responses
    {
        [JsonProperty(PropertyName = "ns1.model")]
        public List<Model> Model { get; set; }
    }
    [JsonObject]
    public class Model
    {
        [JsonProperty(PropertyName = "@mh")]
        public object Mh { get; set; }
        [JsonProperty(PropertyName = "ns1.attribute")]
        public ModelAttribute Attribute { get; set; }
    }
    [JsonObject]
    public class ModelAttribute
    {
        [JsonProperty(PropertyName = "@id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "$")]
        public string Value { get; set; }
    }
    [JsonObject]
    public class Link
    {
        [JsonProperty(PropertyName = "@rel")]
        public string Rel { get; set; }
        [JsonProperty(PropertyName = "@href")]
        public string Href { get; set; }
        
        [JsonProperty(PropertyName = "@type")]
        public string Type { get; set; }
    }
