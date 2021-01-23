    public class MyClass
    {
        private WdmEntities _context;
    
        public List<T> GetTable<T>()
        {
            List<T> res = new List<T>();
            _context = new DbEntities();
            if (typeof(T) == typeof(tables))
                //Just casting the returned list, if the entity type is the same as T
                res = (List<T>)_context.tables.ToList();
            if (typeof(T) == typeof(columns))
                res = (List<T>)_context.columns.ToList();
    
            return res;
        }
    
    }
