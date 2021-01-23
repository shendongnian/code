    using System;
    		
    public static class MoneyExtensions
    {
    	public static string Format(this decimal val){
    		if(val < 0)
    			return "(" + Math.Abs(val).ToString("N2") + ")";
    		else
    			return val.ToString("N2");
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(2.2m.Format());
    		Console.WriteLine((-12.42m).Format());
    	}
    }
