    public class CannotDeserializeThis
    {
        private readonly IList<User> _users = new List<User>();
        public virtual IEnumerable<User> Users => _users.ToList().AsReadOnly();
        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
