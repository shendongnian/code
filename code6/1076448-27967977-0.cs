    using System;
    using System.Reflection;
    
    namespace DemoDynamicT
    {
    	public static class Utilities
    	{
    		public static T FooStruct<T>(this T value) where T:struct
    		{
    			return default(T);
    		}
    
    		public static T FooClass<T>(this T value) where T : class
    		{
    			return default(T);
    		}
    	}
    
    	public class Program
    	{
    		class TestClass
    		{
    			public TestStruct StructField;
    		}
    
    		struct TestStruct
    		{
    			public int x;
    			int y;
    		}
    
    		public static void Main()
    		{
    			var x = new TestClass();
    			Type type = x.GetType();
    			foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    			{
    				var val = fieldInfo.GetValue(x);
    				var methodInfo = typeof(Utilities).GetMethod(fieldInfo.FieldType.IsValueType ? "FooStruct" : "FooClass");
    				var toBeCalled = methodInfo.MakeGenericMethod(fieldInfo.FieldType);
    				object obj = toBeCalled.Invoke(null, new [] {val});
    				fieldInfo.SetValue(x, obj);
    			}
    		}
    	}
    }
