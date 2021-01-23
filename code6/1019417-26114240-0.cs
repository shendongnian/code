    class Mapper
    {
        public TLog GetMapped<TType, TEntity, TLog>(TEntity entity) where TType : A<TEntity, TLog>, new()
        {
            TType instance = new TType();
            return instance.Get(entity);
        }
    }
