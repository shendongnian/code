    public class UserRepository : IUserRepository
    {
        public Configs CustomConfig {get;set;}
        public User GetUserById(string id)
        {
            return CustomConfig.Users.FirstOrDefault(u => u.UserId == id);
        }
    }
