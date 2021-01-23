    public class Employee
    {
        public IEnumerable<User> Employees { set; get; }
    }
    
    public class User
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public bool IsAdmin { set; get; }
        public bool CanWrite { set; get; }
        public string Email{ set; get; }
    }
