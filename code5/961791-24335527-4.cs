    public class Account
    {
        private List<User> _users = new List<User>();
        public IEnumerable<User> Users { get; }
        public void AddUser(User use)
        {
            _users.Add(user);
        }
        public void RemoveUser(User user)
        {
            _users.Remove(user);
            foreach (var group in UserGroups)
                group.Users.Remove(user);
        }
        // ...
     }
