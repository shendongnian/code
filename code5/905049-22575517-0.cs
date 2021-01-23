    public abstract class SpaceshipManager<T>
    {
    	public abstract void BuildWith(T source);
    }
    
    public class StringBuilderSpaceshipManager : SpaceshipManager<ParseObject> { ... }
