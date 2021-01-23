    public class MyUserStore : IUserStore<User>
    {
        private readonly MyDbContext _dbContext;
        public MyUserStore(MyDbContext dbContext) { _dbContext = dbContext; }
    }
