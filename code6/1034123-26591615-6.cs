    using SchoolDemo.Repository.Interface;
    using System.Data.Entity;
    
    namespace SchoolDemo.Repository
    {
        public class DeleteRepository<TEntity>
            : ReadOneRepository<TEntity>        //This was the 1st little change made, changed from BaseRepo
            , IDeleteRepository<TEntity>
              where TEntity : class
        {
    
            public DeleteRepository(DbContext dbContext) 
                : base(dbContext) { }
    
            public int Delete(TEntity entity)
            {
                dbSet.Remove(entity);
                return dbContext.SaveChanges();
            }
        }
    }
