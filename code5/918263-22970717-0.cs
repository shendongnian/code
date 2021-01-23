    public abstract class Loadable<T> where T: Loadable<T>, new()
    {
        private readonly static ConcurrentDictionary<int, T> _cache = new ConcurrentDictionary<int, T>();
        
        private readonly static Func<int, T> _addDelegate = key => {
            T item = new T();
            item.SetData(SQLiteDB.main.getRowById(TableName, key));
            return item;
        };
        
        private static readonly string _tableName;
        
        static Loadable()
        {
            var prop = typeof(T).GetProperty("TableName", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            if (prop == null)
                throw new NotSupportedException(string.Format("Type '{0}' does not support TableName", typeof(T)));
            
            _tableName = (string)prop.GetValue(null);
        }
        
        protected abstract void SetData(DataRow data);
        
        public virtual int Id { get; set; }
        
        public static T GetById(int id)
        {
            return _cache.GetOrAdd(id, _addDelegate);
        }
    }
