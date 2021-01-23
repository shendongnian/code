    public interface IEntity<TDescription>
    {
        TDescription Get();
    }
    
    public class MyModel : IEntity<MyDescription>
    {
         MyDescription Get() { ... }
    }
    
    public class MyDescription { ... }
