    public class User
    {
       public string Id { get; set; }
       public string UserName { get; set; }
       public virtual List<Role> Roles { get; set; }
    }
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
