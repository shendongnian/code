    public interface IFoo : IDisposable
    {
        void Invoke();
    }
    
    public class DataAccessBase : IFoo
    {
        public void Invoke()
        {
            Console.WriteLine("In Invoke() in DataAccessBase.");
        }
    
        public void Dispose()
        {
            Console.WriteLine("In Dispose() in DataAccessBase.");
        }
    }
    
    public static class DataAccessFactory
    {
        public static IFoo Resolve()
        {
            return new DataAccessBase();
        }
    }
