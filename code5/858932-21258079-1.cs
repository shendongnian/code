    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext context;
    
        public UserRepository(MyDbContext context)
        {
            this.context = context;
        }
    }
