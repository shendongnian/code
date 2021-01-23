    public class Program
    {
    	public static void Foo<T>(dynamic obj)
    	{
    		if (!(obj is T))
    		{
    			throw new System.ArgumentException("Expecting " + typeof(T).Name);
    		}
    
    		obj.Cost = "Cost";
    		obj.Rate = "Rate";
        	// obj.Nope = "";
    	}
    
    	public static void Main()
    	{
    		var obj = new Obj1();
    		Foo<Obj1>(obj);
    		Foo<Obj1>(""); // excption
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
