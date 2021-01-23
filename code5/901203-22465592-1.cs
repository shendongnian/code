    [Serializable]
    [JsonObject]
    public class ObjectDeserializationBase : ObjectBase
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
