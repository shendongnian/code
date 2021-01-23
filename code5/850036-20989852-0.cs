    public interface IAView
    {
    
    }
    
    public class BController<TView>
    {
    
    }
    
    public interface IAController
    {
    
    }
    
    public class D : BController<IAView>, IAController
    {
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
