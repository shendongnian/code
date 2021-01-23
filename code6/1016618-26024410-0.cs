    using System;			
    public class Program
    {
    	public static void Main()
    	{
    		string name = "MyName";
    		
    		Console.WriteLine(name??test());
    	}
    	
    	private static string test()
    	{
    		Console.WriteLine("Called");
    		return "Allo";
    	}
    }
