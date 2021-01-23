    public class Foo
    {
        [JsonIgnore]
        public int ParentId { get; set; }
    }
    
    public class Bar: Foo
    {
        [JsonProperty("ParentId")]
        public new int ParentId { get; set; }
    }
