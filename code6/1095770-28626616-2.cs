    public class Foo {}
    
    public sealed class Singleton<T> where T : class, new()
    {
        private static readonly Lazy<T> lazy = new Lazy<T>(() => new T());
        
        public static T Instance { get { return lazy.Value; } }
    
        private Singleton()
        {
        }
    }
    
    void Main()
    {
    	Foo foo1 = Singleton<Foo>.Instance;
    	Foo foo2 = Singleton<Foo>.Instance;
    	
    	if(foo1 == foo2)
    	{
    		Console.WriteLine("Foos are equal");
    	}	
    }
