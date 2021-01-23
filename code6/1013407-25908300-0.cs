    public T Add<T>(string name, string details)
        where T: BaseClass, new()
    {
        T result = new T();
    	//snip	
        return result;
    }
    public abstract class BaseClass { /* snip */ }
    public class ConcreteClass: BaseClass { /* snip */ }
