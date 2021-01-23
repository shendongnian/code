    class User
    {
        ....
        public virtual ICollection<User> CompanyUsers {get; set;} //persistent property
        
        [NotMapped]
        public User FirstCompanyUser   //transient property
        {
             get{ return CompanyUsers.FirstOrDefault(); }
        }
    }
