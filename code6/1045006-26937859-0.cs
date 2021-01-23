    [DataContract]
    public class Credentials
    {
        [DataMember]
        public string Username {get; set;}
        [DataMember]
        public string PasswordMD5 {get; set;}
    }
