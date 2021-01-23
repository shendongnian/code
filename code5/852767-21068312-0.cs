        public class BaseRepository<T> : IRepositoryBase<T> where T : class, IEntity, new()
        {
            protected readonly DbContext InnerDbContext;
            protected DbSet<T> InnerDbSet;
            public BaseRepository(DbContext innerDbContext)
            {
                InnerDbContext = innerDbContext;
                InnerDbSet = InnerDbContext.Set<T>();
            }
            public virtual Task<T> FindAsync(long id)
            {
                return InnerDbSet.FirstOrDefaultAsync(x => x.Id == id);
            }
        }  
