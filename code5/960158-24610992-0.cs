    public interface IUserRepository
    {
         IEnumerable<User> GetUsers();
    }
    public class UserBO
    {
         private readonly IUserRepository _userRepository;
     
         public UserBO(IUserRepository userRepository){
             _userRepository = userRepository;
         }
         public IEnumerable<User> GetUsers()
         {
             return _userRepository.GetUsers();
         }
    }
