    public interface IPersistedObject<T> where T : IPersistedObject<T>
    {
        PersistedElementDefinition<T> Definition {get;}
    }
    public class PersistedElementDefinition<T> where T: IPersistedObject<T>
    {
        ...
    }
    public class MyPersistedObject : IPersistedObject<MyPersistedObject>
    {
        // Here, you are forced to implement a PersistedElementDefinition<MyPersistedObject>,
        // which presumably is the reason behind this whole song and dance
        
        PersistedDefinition<MyPersistedObject> Definition { get; }
    }
