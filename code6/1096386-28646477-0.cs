    using System;
    
    namespace Test
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			int[] notes = new int[] { 100, 50, 20, 10, 5, 2, 1 };
    			int amount = 0;
    
    			amount = Convert.ToInt32 (Console.ReadLine ());
    			foreach (int i in notes) {
    				Console.WriteLine (amount / i);
    				amount = amount % i;
    			}
    		}
    	}
    }
