    public class Staff
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
        public bool Active { get; set; }
        public IsTeamLeader { get; set; }
    
    }
    
    public class Team
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        
        public virtual List<Staff> Members{ get; set; }
    }
