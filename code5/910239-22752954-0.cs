    [DataContract]
    public class S3PolicyDocument
    {
        [DataMember(Name = "expiration")]
        public string expiration { get; set; }
        [DataMember(Name = "conditions")]
        public List<string[]> conditions { get; set; }
        public S3PolicyDocument()
        {
            conditions = new List<string[]>();
        }
    }
