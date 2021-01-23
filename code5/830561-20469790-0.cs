    public interface IUserRepository
    {
       IEnumerable<User> GetAll()
    }
    
    public class UserRepository : IUserRepository
    {
      public IEnumerable<User> GetAll()
      { 
        return DB.Users.All();
      }
    }
   
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
          _userRepository = userRepository
        }
        public Enumerable<User> GetAll(){
            return _userRepository.GetAll();
        }
    }
