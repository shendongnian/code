    public class From
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    public class SharedWith
    {
        [JsonProperty(PropertyName = "access")]
        public string AccessName { get; set; }
    }
    public class ResponseFolder
    {
        public string Id { get; set; }
        public From From { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "shared_with")]
        public SharedWith SharedWith { get; set; }
    }
    public class RootObject
    {
        public List<ResponseFolder> data { get; set; }
    }
