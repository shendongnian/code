    using System;
    
    namespace Test
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string[] data = new string[] { "a", "b", "c", "d", "e", "f" };
    
    			int input = Convert.ToInt32 (Console.ReadLine ());
    			try {
    				Console.WriteLine (data [input]);
    			} catch (IndexOutOfRangeException) {
    				Console.WriteLine ("Invalid input.");
    			}
    		}
    	}
    }
