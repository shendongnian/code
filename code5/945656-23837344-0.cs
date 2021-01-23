    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			object[] options = { 15, 12, 52, "a", 12, 15, "abc", 15 };
    
    			Dictionary<object, int> counts = new Dictionary<object, int>();
    
    			for (var t = 0; t < options.GetLength(0); t++)
    			{
    				if (!counts.ContainsKey(options[t]))
    					counts[options[t]] = 1;
    				else
    					counts[options[t]] = 1 + counts[options[t]];
    			}
    
    			foreach (var entry in counts)
    				Console.Out.WriteLine("Key: " + entry.Key + "; Count: " + entry.Value.ToString());
    		}
    	}
    }
