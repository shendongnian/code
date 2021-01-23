    public partial class User : IdentityUser
    {
        public User()
        {
            this.Logs= new HashSet<Log>();
        }
    
        public int IdUser { get; set; }
        public string AspNetUsersId { get; set; } //References to AspNetUsers.Id
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job{ get; set; }
    
        public virtual ICollection<Log> Logs { get; set; }
    }
