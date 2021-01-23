    public class User
    {
        public User()
        {
            // instantiate navigation property
            this.Roles = new List<Role>();
        }
        public int UserId { get; set; }
        public string UserName {get; set;}
        public virtual ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public Role()
        {
            // instantiate navigation property
            this.Users= new List<User>();
        }
        public int RoleId {get; set;}
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
