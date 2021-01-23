    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UserAddress
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
    }
    IQueryable<User> users;
    IQueryable<UserAddress> addresses;
        
