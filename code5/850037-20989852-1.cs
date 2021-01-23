    private class PrivateClass
    {
        public interface IAView
        {
    
        }
    }
    
    public class BController<TView>
    {
    
    }
    
    public interface IAController
    {
    
    }
    
    public class D : BController<PrivateClass.IAView>, IAController
    {
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
