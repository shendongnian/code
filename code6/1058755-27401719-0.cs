    [DataContract]
    public class Location
    {
        [DataMember(Name = "@id")]
        public string id { get; set; }
        [DataMember(Name = "@x")]
        public string x { get; set; }
        [DataMember(Name = "@y")]
        public string y { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    // etc.
