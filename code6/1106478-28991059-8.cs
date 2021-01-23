    public class Program
    {
    	public static void Foo<T>(dynamic obj)
    	{
    		if (!(obj is T)) 
    		{
    			var message = 
    				string.Format("Expecting type of <{0}>.", typeof(T).Name);
    			throw new System.ArgumentException(message);
    		}
    		obj.Cost = "11.99";
    		obj.Rate = "0.50";
        	
    		// obj.Nope = ""; // RuntimeBinderException
    	}
    
    	public static void Main()
    	{
    		var obj = new Obj1();
    		Foo<Obj1>(obj);
    		System.Console.WriteLine("${0} at ${1}/hr.", obj.Cost, obj.Rate);
    		
    		// Foo<Obj1>(""); // ArgumentException
    	}
    }
    
    public class Obj1
    {
    	public string Cost, Rate;
    }
    
    public class Obj2
    {
    	public string Cost, Rate;
    }
