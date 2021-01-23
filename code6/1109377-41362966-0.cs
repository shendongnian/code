    public class User
    {
        public string Name { get; set; }
      
        public virtual ICollection<UserRole> Roles { get; set; }  
    }
