    public interface IEntityStringId
    {
         String IDString { get; }
    }
    
    public interface IEntityWithTypedId<T> : IEntityStringId
    {
        
    }
