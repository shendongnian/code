    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/ABC")] // The namespace you used.
    public class EmailInfo
    {
        [DataMember(Order = 1)]
        public string Body { get; set; }
        [DataMember(Order = 2)]
        public string CCMail { get; set; }
        [DataMember(Order = 3)]
        public string EmailState { get; set; }
        [DataMember(Order = 4)]
        public string FromEmail { get; set; }
        [DataMember(Order = 6)]
        public string ToEmail { get; set; }
        [DataMember(Order = 5)]
        public string Subject { get; set; }
        [DataMember(Order = 7)]
        public string SessionId { get; set; }
    }
