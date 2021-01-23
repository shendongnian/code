    public class MyUser
    {
        public MyUser(string name, string password, string roleName)
        {
            this.Name = name;
            this.Password = password;
            this.RoleName = roleName;
        }
        public string Name { get; set; }
        public string Password { get; private set; }
        public string RoleName { get; set; }
    }
