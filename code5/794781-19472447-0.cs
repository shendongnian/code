    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
    	class Program
    	{
    		interface Word
    		{
    			String GetResponse();
    		}
    
    		public class Sup : Word
    		{
    			public String GetResponse()
    			{
    				return "Hello back to you!";
    			}
    		}
    
    		public class Lates : Word
    		{
    			public String GetResponse()
    			{
    				return "Sorry to see you go.";
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			var sup = new Sup();
    			var lates = new Lates();
    			var mapping = new Dictionary<String, Word>(StringComparer.OrdinalIgnoreCase)
    			{
    				{"hi", sup},
    				{"hello", sup},
    				{"hey", sup},
    				{"bye", lates},
    				{"later", lates},
    				{"astalavista", lates},
    			};
    
    			Word word;
    			if (mapping.TryGetValue("HELLO", out word))
    				Console.WriteLine(word.GetResponse());
    
    			if (mapping.TryGetValue("astalavista", out word))
    				Console.WriteLine(word.GetResponse());
    
    			if (mapping.TryGetValue("blaglarg", out word))
    				Console.WriteLine(word.GetResponse());
    		}
    	}
    }
