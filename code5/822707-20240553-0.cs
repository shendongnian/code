    public abstract class BaseRepository<T> where T : class
    {
        private static DBEntities dbEntities;
    
        public BaseRepository()
        {
            dbEntities = new DBEntities();
        }
        public IQueryable GetTable(T entity) 
        {
            return dbEntities.CreateObjectSet<T>();
        }
    
        public void Insert(T obj)
        {
           //the line below gives an error 'The Type T must be a reference type
           // in order to use it as parameter T. I HAVE tried adding ref here
           // and in GetTable method, but same error
           var table = GetTable(obj);        
           int saveChanges = dbEntities.SaveChanges();    
        }
    }
