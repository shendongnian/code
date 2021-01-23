    public interface IDo {}
    public class DoOneThing : IDo {}
    public class DoAnotherThing : IDo {}
    public interface IFooService
    {
        IDo Do { get; }
    }
    
    public class FooService : IFooService
    {
        public FooService(IDo @do)
        {
            Do = @do;
        }
        
        public IDo Do { get; private set; }
    }
