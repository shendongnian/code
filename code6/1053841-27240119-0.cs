    public class User
    {
        public int ID { get; set; }
    
        [ForeignKey("ID")]
        public virtual ICollection<Connection> OutgoingConnections { get; set; }
    
        [ForeignKey("ID")]
        public virtual ICollection<Connection> IncomingConnections { get; set; }
    }
    
    public class Connection
    {
        public int ID { get; set; }
    
        public int SourcerId {get;set;}
       
        public int DestUserId {get;set;}
    
        [ForeignKey("SourcerId")]
        public User SourceUser { get; set; }
    
         [ForeignKey("DestUserId")]
        public User DestUser { get; set; }
    }
