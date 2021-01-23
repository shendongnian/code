    public class Program
    {
    	public static void Foo<T>(dynamic obj)
    	{
    		if (!(obj is T))
    		{
    			throw new System.ArgumentException("Expecting {0} or {1}.");
    		}
    
    		obj.Cost = "Cost";
    		obj.Rate = "Rate";
    	// obj.Nope = "";
    	}
    
    	public static void Main()
    	{
            // calling code
    		var obj = new Obj1();
    		Foo<Obj1>(obj);
    	}
    }
    
    public class Obj1
    {
    	public string Cost;
    	public string Rate;
    }
    
    public class Obj2
    {
    	public string Cost;
    	public string Rate;
    }
