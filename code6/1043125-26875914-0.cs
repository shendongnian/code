    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Bar.DoStuff();
    	}
    	
    	private static class Bar
    	{
    		public static void DoStuff()
    		{
    			Console.WriteLine("Test");
    		}
    	}
    }
