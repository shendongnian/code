    public interface IFirst
    {
    	ISecond Child { get; }
    	void WriteHierarchy();
    }
    
    public interface ISecond
    {
    	IThird Child { get; }
    }
    
    public interface IThird
    {
    	IFourth Child { get; }
    }
    
    public interface IFourth
    {
    }
    
    public class ObjectA : IFirst
    {
    	public ObjectA(ISecond child)
    	{
    		this.Child = child;
    	}
    	
    	public ISecond Child { get; private set; }
    	
    	public void WriteHierarchy()
    	{
    		Console.WriteLine("{0} -> {1} -> {2} -> {3}",
    			this.GetType().Name,
    			this.Child.GetType().Name,
    			this.Child.Child.GetType().Name,
    			this.Child.Child.Child.GetType().Name);
    	}
    }
    
    public class ObjectB : ISecond
    {
    	public ObjectB(IThird child)
    	{
    		this.Child = child;
    	}
    	
    	public IThird Child { get; private set; }
    }
    
    public class ObjectC : IThird
    {
    	public ObjectC(IFourth child)
    	{
    		this.Child = child;
    	}
    	
    	public IFourth Child { get; private set; }
    }
    
    public class ObjectF : IThird
    {
    	public ObjectF(IFourth child)
    	{
    		this.Child = child;
    	}
    	
    	public IFourth Child { get; private set; }
    }
    
    public class ObjectD : IFourth
    {
    }
