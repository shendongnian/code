    public interface IUserRepository : IRepository<User>
        {
            IQueryable<User> AllAuthorized();
            IQueryable<User> AllConfirmed();
        }
