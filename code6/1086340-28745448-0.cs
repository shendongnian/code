    [DataContract]
    public class AuthHeader
    {
        [DataMember]
        public string Username { get; set; }
    
        [DataMember]
        public string Password { get; set; }
    }
