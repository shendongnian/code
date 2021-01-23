    public interface IPersistentEntity 
    {
        bool IsNew { get; } 
    }
    public interface IPersistentEntity<T> : IPersistentEntity
    {
        T Id { get; }
    }
