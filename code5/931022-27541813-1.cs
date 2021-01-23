    public class ClientListModel
    {
        [DataMember(Name = "clientId")]
        public int ClientId { get; set; }
    
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
    
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
    
        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; set; }
    
        [DataMember(Name = "status")]
        public string Status { get; set; }
    
        public ClientListModel()
        {}
    }
