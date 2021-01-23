    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			List<string> listofstrings = new List<string> ();
    			string input = null;
    
    			while ((input = Console.ReadLine ()) != string.Empty) {
    				listofstrings.Add (input);
    			}
    		}
    	}
    }
