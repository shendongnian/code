    public class User
    {
        public int UserId { get; set; } // just assuming int key ID
        public string UserName { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
