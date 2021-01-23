    public interface IUserRepository : IRepository<User>
    {
        void Authenticate(Useruser);
    }
    
    // and it's implementation:
    
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public void Authenticate(User user)
        {
            // do some stuff here
        }
    }
