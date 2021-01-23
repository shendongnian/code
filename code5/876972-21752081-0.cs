    public class DBGroupMessage
    {
        public DBGroup Group { get; set; }    
        [Required]
        public Guid GroupID { get; set; }    
        public Guid Id { get; set; }    
        public DBUser Owner { get; set; }    
        public Guid? OwnerID { get; set; }
    }
