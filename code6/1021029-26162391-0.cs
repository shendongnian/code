    public class UserCollection : Collection<User>
    {
        public UserCollection() { }
        public UserCollection(IList<User> users) : base(users) { }
        public static UserCollection GetUserCollection()
        {
            // ...
            List<User> userList = ... 
            return new UserCollection(userList);
        }
    }
