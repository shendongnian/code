    class UserRepository
    {
        // if you don't want to expose properties but only access them via method calls...
        private List<User> Users { get; }
        public UserRepository()
        {
            // get Users from Database or any other source...
            Users = db.Users;
        }
        public List<User> GetAllUsers()
        {
            return Users;
        }
        public void AddUser(User u)
        {
            // simple example, would normally handle validation etc.
            Users.Add(u);
        }
    }
