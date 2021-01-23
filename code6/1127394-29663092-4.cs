    using System;
    using System.Reflection;
    
    public static class Program
    {
    	public static void Main()
    	{
    		MethodInfo methodToInvoke = typeof(MyClass)
    			.GetOverloadedMethod("myFunc", new System.Type[] { typeof(BaseClass) });
    		
    		var result = methodToInvoke
    			.Invoke(new MyClass(), new object[] { new BaseClass() });
    		
    		Console.WriteLine(result);		
    	}
    	
    	public static MethodInfo GetOverloadedMethod(this Type type, string funcName, System.Type[] parameters)
    	{
    		var methodInfo = type.GetMethod(funcName, parameters);
    		return methodInfo;
    	}
    
    	public class MyClass
    	{
    		public static string myFunc(BaseClass bc)
    		{
    			return "BaseClass";
    		}
    
    		public static string myFunc(DerivedClass dc)
    		{
    			return "DerivedClass";
    		}
    	}
    
    	public class BaseClass { }
    
    	public class DerivedClass : BaseClass { }
    }
