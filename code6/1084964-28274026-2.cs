    public interface IMyClass
    {
    	string Name { get; set; }
    }
    public class MyClass : IMyClass
    {
    	public string Name { get; set; }
    }
    
    public class MyClassWrapper: IMyClass
    {
        MyClass _obj;
    	public MyClassWrapper(MyClass obj)
    	{
    		_obj = obj;	
    	}
    	
    	public string Name
    	{
    		get { return _obj.Name; }
    		set { _obj.Name = value; }
    	}
    }
