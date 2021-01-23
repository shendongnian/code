    [JsonObject(MemberSerialization.OptIn)]
    public class MyClass
    {
        [JsonProperty]
        public string serializedProp { get; set; }
        
        public string nonSerializedProp { get; set; }
    }
