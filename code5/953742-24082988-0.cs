    public class MyClass
    {
    	public class Test
    	{
    		public int TestMethod(int a, int b)
    		{
    			return a + b;
    		}
    	}
    
    	public static void Main()
    	{
    		int result = ExecuteMethod<Test, int>("TestMethod", 1, 2);
    		Console.Read();
    	}
    
    	public static TResult ExecuteMethod<TClass, TResult>(string methodName, params object[] parameters)
    	{
    		// Instantiate the class (requires a default parameterless constructor for the TClass type)
    		var instance = Activator.CreateInstance<TClass>();
    
    		// Gets method to execute
    		var method = typeof(TClass).GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
    
    		// Executes and returns result
    		return (TResult)method.Invoke(instance, parameters);
    	}
    }
