    public class Singleton
    {
    	static Singleton()
    	{
    		Instance = new Singleton();
    	}
    
    	public static Singleton Instance { get; private set; }
    }
