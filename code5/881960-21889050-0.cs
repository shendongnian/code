    public class SqlRepository<T>: IRepository<T> where T: class, IEntity
    {
        protected readonly DbSet<T> _objectSet;
        public SqlRepository(ApplicationDbContext context)
        {
            _objectSet = context.Set<T>();
        }
    }
