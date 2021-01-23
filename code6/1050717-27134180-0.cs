    [DataContract]
    public class User
    {      
        [DataMember(Name="email")]
        public string EmailAddress { get; set; }
      
        
        [DataMember(Name = "name")]
        public string Name { get; set; }
 
