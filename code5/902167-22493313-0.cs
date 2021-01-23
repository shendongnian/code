    [DataContract]
    public class TestSerialization
    {
        [DataMember(Name = "field_one")]
        public string ItemOne { get; set; }
    
        [DataMember(Name = "field_two")]
        public string ItemTwo { get; set; }
    }
