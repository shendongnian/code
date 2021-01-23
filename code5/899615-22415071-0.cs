    [DataContract]
    public class FolderRequest
    {
        [DataMember(Name = "data")]
        public ResponseFolder[] data { get; set; }
    }
