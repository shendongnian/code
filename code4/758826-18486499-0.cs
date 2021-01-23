    public class MyClass
    {
        private WdmEntities _context;
    
        public List<T> GetTable<T>()
        {
            List<T> res = new List<T>();
            _context = new DbEntities();
            if (typeof(T) == typeof(tables))
                // If the defined entity type is an abstract class or interface
                // while the returned type from the dbcontext really is of your object type
                res = _context.tables.Cast<T>().ToList();
            if (typeof(T) == typeof(columns))
                res = _context.columns.Cast<T>().ToList();
    
            return res;
        }
    
    }
