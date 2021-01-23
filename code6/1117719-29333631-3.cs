    using System;
    using System.Dynamic;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		dynamic resultItem = new ExpandoObject();
    		resultItem.Name = "John Smith";
    		resultItem.Age = 33;
            // cast as IDictionary
    		foreach (var property in (IDictionary<String, Object>)resultItem)
    		{
    			Console.WriteLine(property.Key + ": " + property.Value);
    		}
    	}
    }
