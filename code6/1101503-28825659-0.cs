    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string mySum = "200+800";
    		int totalSum = 0;
    		foreach(var op in mySum.Split('+'))
    		{
    			totalSum += Convert.ToInt16(op);
    		}
    		Console.WriteLine(totalSum);
    	}
    }
