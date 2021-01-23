    [DataContract(Namespace = "")]
    [KnownType(typeof(CommentList))]
    public class CFCConnectResponse
    {
        [DataMember]
        public int StatusCode;
        [DataMember]
        public string StatusDescription;
        [IgnoreDataMember]
        public List<string> Comments { get; set; }
        [DataMember(Name = "comments")]
        private CommentList SerializableComments
        {
            get
            {
                return new CommentList(Comments);
            }
            set
            {
                Comments = value.ToList();
            }
        }
    }
