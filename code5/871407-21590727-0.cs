    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            // linq query
        }
        public IList<User> GetAll()
        {
            // another query
        }
    
        public IList<User> GetUsersByRole(string role)
        {
            // yet another query
        }
    }
