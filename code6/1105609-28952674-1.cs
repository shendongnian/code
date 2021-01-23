    public class DataRepository<C,T> : IRepository<T> where T : class where C : ObjectContext, new()
    {
        private ObjectContext _context;
        private IObjectSet<T> _objectSet;
        public DataRepository() : this(new C()) { }
        public DataRepository(ObjectContext context)
        {
           _context = context;
           _objectSet = _context.CreateObjectSet<T>();
        }
        public void Add(T entity)
        {
           if(entity == null) throw new ArgumentNullException("entity");
           _objectSet.AddObject(entity);
        }
        public void Delete(Func<T, bool< predicate)
        {
            var records = from x in _objectSet.Where<T>(predicate) select x;
            foreach(T record in records)
               _objectSet.DeleteObject(record);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        // Other members
        // IDisposable members
    }
