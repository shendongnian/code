    [DataContract]
    public class Project
    {
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    
        [DataMember]
        public Dictionary<string, Tag> tags { get; set; }
    }
    
    [DataContract]
    public class Tag
    {
        [DataMember]
        public string date { get; set; }
    
        [DataMember]
        public string author { get; set; }
    }
