    [DataContract(Namespace = "YourNamespaceHere")]
    public class DataRequest
    {
        [DataMember]
        public string ID{ get; set; }
        [DataMember]
        public string Data{ get; set; }
    }
