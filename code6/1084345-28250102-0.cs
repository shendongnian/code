    [DataContract(Namespace = "")]
    public class LoginDTO
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
