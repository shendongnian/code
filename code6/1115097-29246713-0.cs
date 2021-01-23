    using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		var n = unchecked((int)470259123000000.0);
    		Console.WriteLine(n);
    		
    		n = (int)Convert.ToDouble("470259123000000", CultureInfo.InvariantCulture);
    		Console.WriteLine(n);
    	}
    }
