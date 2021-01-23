    public class DbContext
    {
        public string Name { get; set; }
    }
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
    }    
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbContext DbContext { get { return _dbContext; } }
    }
    public interface IOrderRepository
    {
        IUnitOfWork UnitOfWork { get;}
    }
    public class OrderRepository : IOrderRepository
    {
        private IUnitOfWork _uow;
        private IFooAdditionalDependency _foo;
        public OrderRepository(IUnitOfWork uow, IFooAdditionalDependency foo)
        {
            _uow = uow;
            _foo = foo;
        }
        public IUnitOfWork UnitOfWork { get { return _uow; } }
    }
    public interface IFooAdditionalDependency { }
    public class FooAdditionalDependency : IFooAdditionalDependency
    {
    }
    public interface IUserRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
    public class UserRepository : IUserRepository
    {
        private IUnitOfWork _uow;        
        public UserRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IUnitOfWork UnitOfWork { get { return _uow; } }
    }
    public interface ITokenRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
    public class TokenRepository : ITokenRepository
    {
        private IUnitOfWork _uow;
        public TokenRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IUnitOfWork UnitOfWork { get { return _uow; } }
    }
