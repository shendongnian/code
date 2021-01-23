    [DataContract]
    public class EntityA
    {
        [DataMember]
        public string SerializeThisProperty { get; set; }
    
        [NotMapped]
        public string DoNotSerializeThisProperty { get; set; }
    }
