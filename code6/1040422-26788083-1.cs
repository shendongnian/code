    using System;
     
    public class Test
    {
    	public static void Main()
    	{
    		bool a = true;
    		bool b = true;
    		bool c = false;
     
    		Console.WriteLine(a || b && c);
    		Console.WriteLine((a || b) && c);
    		Console.WriteLine(a || (b && c));
    	}
    }
