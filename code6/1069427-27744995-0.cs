    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string text = "FundList[15].Amount";
             var result = Convert.ToInt32(Regex.Replace(text, @"[^\d]+",""));
    		Console.WriteLine("Result is = {0}", result);
    	}
    }
