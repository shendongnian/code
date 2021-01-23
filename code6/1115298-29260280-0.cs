    [DataContract]
    public class Entity
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
    
        [DataMember(Name = "a")]
        public int? A { get; set; }
    
        [DataMember(Name = "b")]
        public int? B { get; set; }
    
        [DataMember(Name = "c")]
        public int? C { get; set; }
    }
