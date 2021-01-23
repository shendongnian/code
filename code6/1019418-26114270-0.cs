    public class Mapper
    {
        private readonly Dictionary<Type, object> _instances;
    
        public Mapper()
        {
            _instances = new Dictionary<Type, object>()
            {
                { typeof(Branch), new B() },
                ...
            };
        }
        public TLog GetMapped<TEntity, TLog>(TEntity entity)
        {
            A<TEntity, TLog> a = (A<TEntity, TLog>) _instances[typeof(TEntity)];
            return a.Get(entity);
        }
    }
