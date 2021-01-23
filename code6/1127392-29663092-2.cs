    using System;
    using System.Reflection;
    
    public static class Program
    {
    	public static void Main()
    	{
    		var methodInfo = typeof(MyClass).GetMethod("myFunc", new Type[] { typeof(BaseClass) });
    		var result = methodInfo.Invoke(new MyClass(), new object[] { new BaseClass() });
    		Console.WriteLine(result);		
    		
    		MethodInfo methodToInvoke 
    			= typeof(MyClass).GetOverloadedMethod("myFunc", new System.Type[] {typeof(BaseClass)});
    		
    		var result2 = methodToInvoke.Invoke(new MyClass(), new object[] { new BaseClass() });
    		Console.WriteLine(result2);		
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
    
    		public static void myFunc(DerivedClass dc)
    		{
    		}
    	}
    
    	public class BaseClass
    	{
    	}
    
    	public class DerivedClass : BaseClass
    	{
    	}
    }
