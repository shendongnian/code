    public class UserBLL : IBLLMethods<User>
    {
        private DALMethods<User> _repository;
        private UserContext _db;
    
        public UserBLL()
        {
            _db = new UserContext();
            _repository = new DALMethods<User>(_db);
        }
    
        public bool CreateUserIfNameIsBob(User user)
        {
            // Create bob if bob
            if (user.Name == "Bob")
            {
                _repository.Create(user);
                return true;
            }
            
            // Not bob
            return false;
        }
    }
