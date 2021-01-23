    public interface IObjectWithNameProperty
    {
    	string Name {get; set;}
    }
    
    public class MyNameComparer : IComparer<IObjectWithNameProperty>
    {
    	public int Compare(IObjectWithNameProperty x, IObjectWithNameProperty y)
    	{
    		...
    	}
    }
    
    public class Car: IObjectWithNameProperty
    {
    	 public string Name  {get;set;}
    	 ...
    }
    public class Dog: IObjectWithNameProperty
    {
    	 public string Name  {get;set;}
    	 ...
    }
