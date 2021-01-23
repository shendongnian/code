    using System.Runtime.Serialization;
    [DataContract]
    public class Response
    {
        [DataMember(Name = "conditions")]
        public string Terms { get; set; }
        [DataMember]
        public string Foo { get; set; }
        public int Bar { get; set; } // Will not be mapped
    }
