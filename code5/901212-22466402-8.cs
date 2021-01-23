    [Serializable]
    [JsonObject]
    public class ObjectBase
    {
        public string Id { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool ShouldSerializeId()
        {
            return false;
        }
        public bool ShouldSerializeCreatedDate()
        {
            return false;
        }
        public bool ShouldSerializeLastModifiedDate()
        {
            return false;
        }
    }
