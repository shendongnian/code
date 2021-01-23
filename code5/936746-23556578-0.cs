    public static T Map<TEntity,T>(this TEntity entity) where TEntity : IEntity
    {
        return Mapper.Map<TEntity, T>(entity);        
    }
    
    public static T Map<T>(this ExchangeSet set)
    {
        // ...
    }
