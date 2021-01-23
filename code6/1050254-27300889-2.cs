    public class DALMethods<T> : IDALMethods<T> where T : class
        {
            private UserContext _db;
            private DbSet<T> _set;
    
            public DALMethods(UserContext db)
            {
                _db = db;
                _set = _db.Set<T>();
            }
    
            public void Create(T entity)
            {
                _set.Add(entity);
                _db.SaveChanges();
            }
    
            //... Expressly dispose context method needed.
        }
