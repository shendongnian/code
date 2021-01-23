    public interface IRepository<T> where T : class
    {
        void Add(T model);
        void Edit(T model);
        void Delete(T model);
        T Get(object id);
        IQueryable<T> List();
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        DatabaseContext context;
        DbSet<T> dbSet;
        public Repository(DatabaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public void Add(T model)
        {
            dbSet.Add(model);
        }
        public void Edit(T model)
        {
            dbSet.Attach(model);
            context.Entry(model).State = EntityState.Modified;
        }
        public void Delete(T model)
        {
            if (context.Entry(model).State == EntityState.Detached)
            {
                dbSet.Attach(model);
            }
            dbSet.Remove(model);
        }
        public T Get(object id)
        {
            return dbSet.Find(id);
        }
        public IQueryable<T> List()
        {
            return dbSet;
        }
    }
