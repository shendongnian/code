    public abstract class RepositoryBase<T> where T : class
    {
        private YourEntities dataContext;
        //Constructor to set dataContext and other methods are skipped for simplicity..
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
    }
       
