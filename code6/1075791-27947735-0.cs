    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
       
        public int ActionId { get; set; }
        public virtual Action Action { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
