     public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(Guid id);
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // your implementation
        // NOTE: with EF you could have one open generic implementation
    }
    //registration:
    container.RegisterOpenGeneric(typeof(IRepository<>), 
           typeof(Repository<>), yourDesiredLifestyle);
    //use like:
    public class Foo
    {
        private readonly IRepository<User> userRepository;
        public Foo(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
    }
