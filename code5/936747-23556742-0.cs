    public static MapExtensionHelper<TEntity> Map<TEntity>(this TEntity entity) where TEntity : IEntity
    {
        return new MapExtensionHelper<TEntity>(entity);        
    }
    public class MapExtensionHelper<TEntity> where TEntity : IEntity
    {
        public MapExtensionHelper(TEntity entity)
        {
            _entity = entity;
        }
        private readonly TEntity _entity;
        public T To<T>()
        {
            return Mapper.Map<TEntity, T>(_entity);
        }
    }
