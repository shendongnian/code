    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
     
        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        public string Email { get; set; }
    
        [DataMember]
        public string LastName {get; set; }
    
        // NB Password won't be in EdmModel but still available to EF
        public string Password {get; set;}
    }
