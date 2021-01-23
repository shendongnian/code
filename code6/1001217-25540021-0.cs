    [JsonObject(MemberSerialization.OptIn)]
    public class Node
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "PubDate")]
        public DateTime PubDate { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class MyApiResponse
    {
        [JsonProperty(PropertyName = "Success")]
        public bool Success { get; set; }
    
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
    
        [JsonProperty(PropertyName = "Nodes")]
        public List<Node> Nodes { get; set; }
    }
