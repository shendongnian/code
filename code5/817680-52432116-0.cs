    [DataContract]
    public class ContactHubSpotModel {
    // snip for brevity 
    [DataMember(Name = "properties")]     
    public Dictionary<string, ContactProperty> Properties { get; set; }
    }
    [DataContract]
    public class ContactProperty
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }
        [DataMember(Name = "versions")]
        List<ContactPropertyVersion> Versions { get; set; }
    }
    [DataContract]
    public class ContactPropertyVersion
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }
        [DataMember(Name = "source-type")]
        public string SourceType { get; set; }
        [DataMember(Name = "source-id")]
        public string SourceId { get; set; }
        [DataMember(Name = "source-label")]
        public string SourceLabel { get; set; }
        [DataMember(Name = "timestamp")]
        public long Timestamp { get; set; }
        [DataMember(Name = "selected")]
        public bool Selected { get; set; }
    }
