    public interface IEntity
    {
        IDescription Get();
    }
    
    public interface IDescription { ... }
    
    public class MyModel : IEntity
    {
        MyDescription Get() { ... }
        IDescription IEntity.Get() { return this.Get(); }
    }
    
    public class MyDescription : IDescription { ... }
