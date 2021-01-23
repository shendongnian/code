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
        private readonly DbContext _dbContext;
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
    public class BaseRepository
    {
        private readonly IUnitOfWork _uow;
        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IUnitOfWork UnitOfWork { get { return _uow; } }
    }
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private IFooAdditionalDependency _foo;
        public OrderRepository(IUnitOfWork uow, IFooAdditionalDependency foo)
            : base(uow)
        {
            _foo = foo;
        }
    }
    public interface IFooAdditionalDependency { }
    public class FooAdditionalDependency : IFooAdditionalDependency
    {
    }
    public interface IUserRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
    public interface ITokenRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
    public class TokenRepository : BaseRepository, ITokenRepository
    {
        public TokenRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
