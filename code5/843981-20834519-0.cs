    public abstract class AbstractRepository<T> where T : class
    {
        /// <summary>
        /// Common context per request
        /// </summary>
        protected static ocm Context
        {
            get 
            { 
                if (HttpContext.Current != null)
                {
                    var db = HttpContext.Current.Items["DbContext"] as MyObjectContext
                    if (db == null)
                    {
                        db = new MyObjectContext();
                        HttpContext.Current.Items.Add("DbContext", db);
                    }
                    return db;
                }
                return new MyObjectContext();
            }
        }
    
        public T Get(decimal id)
        {
            return Context.Set<T>().Find(id);
        }
    
        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
    
        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
    
        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }
    
        public void Remove(T obj)
        {
            Context.Set<T>().Remove(obj);
        }
    
        public void Attach(T obj)
        {
            Context.Set<T>().Attach(obj);
        }
    
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
