    [DataContract(Namespace = "")]
    [KnownType(typeof(CommentList))]
    public class CFCConnectResponse
    {
        [DataMember]
        public int StatusCode;
        [DataMember]
        public string StatusDescription;
        [DataMember(Name="comments")]
        public CommentList Comments;
    }
    [CollectionDataContract(ItemName = "comment", Namespace="")]
    public class CommentList : List<string>
    {
        public CommentList()
            : base()
        {
        }
        public CommentList(params string[] strings)
            : base(strings)
        {
        }
        public CommentList(IEnumerable<string> strings)
            : base(strings)
        {
        }
    }
