    [DataContract]
    public class Data
    {
        [DataMember(Name = "_entries")]
        public string[] Entries { get; set; }
        [DataMember(Name = "_flow")]
        public IDictionary<string, Flow> Flow { get; set; }
    }
    [DataContract]
    public class Flow
    {
        [DataMember(Name = "_expr")]
        public Expression[] Expressions { get; set; }
    }
    [DataContract]
    public class Expression
    {
        [DataMember(Name = "word_")]
        public string Word { get; set; }
        [DataMember(Name = "next_")]
        public Expression[] Next { get; set; }
    }
