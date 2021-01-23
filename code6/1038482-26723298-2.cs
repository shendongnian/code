    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public class MyClass
    	{
    		public int Value { get; set; }	
    	}
    	
    	public delegate void Func<out T>(out IDictionary<string, object> objects);
    	
    	public static void Main()
    	{
    		Func<int> someFunc = (out IDictionary<string, object> objects) => 
    		{
    			var obj1 = new MyClass { Value = 1 };
    			var obj2 = new MyClass { Value = 2 };
    			
    			int result = obj1.Value + obj2.Value;
    			
    			objects = new Dictionary<string, object> { { "obj1", obj1 }, { "obj2", obj2 } };
    			
    		};
    		
    		IDictionary<string, object> objectsInFunc;
    		
    		someFunc(out objectsInFunc);
    		
    	}
    }
       
    
