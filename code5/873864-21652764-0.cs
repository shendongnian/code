     public interface IRepository<T> where T : class
     {
         IQueryable<T> All();
         IQueryable<T> Find(Expression<Func<T, bool>> predicate);        
         T GetById(int id);
         
         // and the rest of your methods
     }
