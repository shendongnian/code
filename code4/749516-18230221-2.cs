    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int UserRole { get; set; }
        [DataMember]
        public string LoweredUserName { get; set; }
    }
