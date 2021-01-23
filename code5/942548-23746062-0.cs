    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserEmail { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
