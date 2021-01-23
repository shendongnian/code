    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
     public class MyClassType
     {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Manager")]
        public string Manager { get; set; }
        [JsonProperty(PropertyName = "LastUpdate")]
        public DateTime LastUpdate { get; set; }
     }
