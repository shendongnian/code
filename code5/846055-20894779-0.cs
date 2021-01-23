    public abstract class BaseEntity
    {
        public string Id { get; set; }
    }
    public class ChildObject : BaseEntity 
    {
        public string Name { get; set; }
        public bool IsFullyPopulated { get; set; }
    }
    public class MyObject
    {
        [JsonProperty("ChildObject1")]
        [JsonConverter(typeof(MyCustomObjectConverter))]
        public ChildObject ChildObject1 { get; set; }
        [JsonProperty("ChildObject2")]
        [JsonConverter(typeof(MyCustomObjectConverter))]
        public ChildObject ChildObject2 { get; set; }
        [JsonProperty("ChildObject3")]
        [JsonConverter(typeof(MyCustomObjectConverter))]
        public ChildObject ChildObject3 { get; set; }
    }
