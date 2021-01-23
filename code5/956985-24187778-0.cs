    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {   
    	class A
    	{
    	   public int Id;
    	   public float Value;
    	}
    	public static void Main()
    	{
    		var collection = new List<A>{
    			new A { Id = 1, Value = 1.0f },
    			new A { Id = 5, Value = 5.0f },
    			new A { Id = 6, Value = 6.0f },
    			new A { Id = 10, Value = 10.0f },
    			new A { Id = 11, Value = 11.0f },
    			new A { Id = -289, Value = -289.0f },
    			new A { Id = 123, Value = 123.0f },
    			new A { Id = 3, Value = 3.0f }
    		};
    		
    		foreach (var a in collection.OrderBy(v => v.Value))
    		{
    			Console.WriteLine(a.Value);
    		}
    	}
    }
