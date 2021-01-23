    using SchoolDemo.Repository.Interface;
    using System.Data.Entity;
    
    namespace SchoolDemo.Repository
    {
        public class ReadOneRepository<TEntity>
            : BaseRepository<TEntity>
            , IReadOneRepository<TEntity>
              where TEntity : class
        {
            //public ReadOneRepository() : base() { }
    
            public ReadOneRepository(DbContext dbContext)
                : base(dbContext) { }
    
            public TEntity Read(int id)
            {
                return dbSet.Find(id);
            }
        }
    }
