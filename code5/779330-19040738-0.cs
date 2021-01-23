    public interface IBaseClass
    {
    	
    }
    public class BaseClass : IBaseClass
    {
    
    }
    
    public class ChildClass : BaseClass, IBaseClass {
        
    }
    
    public void SomeCall(IBaseClass BassClass)
    {
    	BassClass.Dump();
    }
    
    public void SomeCall(List<IBaseClass> BassClasses)
    {
    	BassClasses.Dump();
    }
    void Main()
    {
    	List<IBaseClass> _ch = new List<IBaseClass>();
    	_ch.Add(new ChildClass());
    	_ch.Add(new ChildClass());
    	_ch.Add(new ChildClass());
    		
    	SomeCall(_ch);
    }
    
    // Define other methods and classes here
