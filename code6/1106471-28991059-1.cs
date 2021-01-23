    public class Program
    {
    	public static bool CheckType(dynamic obj)
    	{
    		var validNames = typeof(Obj1).Name + "|" + typeof(Obj2).Name; 
    		var typeName = obj.GetType().Name;
    		if (!validNames.Contains(typeName))
    		{
    			throw new System.ArgumentException("Expecting {0} or {1}.");
    		}
    		return true;
    	}
    	
    	public static void Foo(dynamic obj)
    	{
    		if(CheckType(obj)) 
            {
    			obj.Cost = "Cost";
    			obj.Rate = "Rate";
    			// obj.Nope = "";
    		}
    	}
    	
    	public static void Main()
    	{	
    		Foo(new Obj1());
    	}
    }
    public class Obj1
    {
    	public string Cost { get; set; }
    	public string Rate { get; set; }
    }
    
    public class Obj2
    {
    	public string Cost { get; set; }
    	public string Rate { get; set; }
    }
 
