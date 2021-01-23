    public class Program
    {
    	public static void Main()
    	{
    		var methodInfo = 
                typeof(MyClass)
                .GetMethod("myFunc", new Type[] { typeof(BaseClass) });
    		
            var result = 
                methodInfo
                .Invoke(new MyClass(), new object[] { new BaseClass() });
    		
            Console.WriteLine(result);
    	}
    
    	public class MyClass
    	{
    		public static string myFunc(BaseClass bc)
    		{
    			return "BaseClass";
    		}
    
    		public static void myFunc(DerivedClass dc)
    		{
    		}
    	}
    
    	public class BaseClass { }
    
    	public class DerivedClass : BaseClass { }
    }
