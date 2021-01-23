    class Program
    {
        static void Main(string[] args)
        {
            Role[] _roles;
            _roles = new[] {Role.Admin, Role.User};
            
            Console.WriteLine( _roles.Contains((Role)0)); // True
            Console.WriteLine(_roles.Contains((Role)1)); // True
            Console.WriteLine(_roles.Contains((Role)2)); // False
            Role role = (Role)Enum.Parse(typeof (Role), "Admin");
            Console.WriteLine(_roles.Contains(role)); // True
        }
        public enum Role
        {
            Admin,
            User,
            Guest
        }
    }
