    public class User
    {
        public int UserId { get; set; }
        public string Col1 { get; set; }
        //More to be here
    
        public virtual ICollection<ClientUser> Clients { get; set; }
    }
    
    public class ClientUser
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
    
        public virtual User User {get; set;}
    }
