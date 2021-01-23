    public class GenericRepository<T>: IDisposable  where T : class
    {
        private SabaDataEntity db = null;
        private DbSet<T> table = null;
        static readonly GenericRepository<T> instance = new GenericRepository<T>();
        public static readonly GenericRepository<T> Instance
        {
            get
            {
                return instance;
            }
        }
        public GenericRepository()
        {
            this.db = new SabaDataEntity();
            table = db.Set<T>();
        }
        public List<T> getAll()
        {
            return table.ToList();
        }
        public T getById(int id)
        {
            return table.Find(id);
        }
    }
