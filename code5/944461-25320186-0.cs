    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int first = 48030;
    		int last = 48039;
    		
    		Console.WriteLine(CreateRange(first, last, 6));
    	}
    	
    	public static string CreateRange(int first, int last, int numDigits)
    	{
    		string separator = ", ";
    		
    		var sb = new StringBuilder();
    		sb.Append(first.ToString().PadLeft(numDigits, '0'));
    		
    		foreach (int num in Enumerable.Range(first + 1, last - first))
    		{
    			sb.Append(separator + num.ToString().PadLeft(numDigits, '0'));
    		}
    		
    		return sb.ToString();
    	}
    }
