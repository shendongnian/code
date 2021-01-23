    public class AdminViewModel
    {
        public List<User> UserList { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public bool IsAdmin { get; set; }
    }
