    public interface IUserRepository : IRepository<IUser>
    {
        void Authenticate(IUser user);
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public void Authenticate(IUser user)
        {
            // do some stuff here
        }
    }
