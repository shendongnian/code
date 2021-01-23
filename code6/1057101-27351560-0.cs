    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string input = "abc,pqr lmn,rty qqq.ttt";
    
    		string output = Regex.Replace(input, @"\W", ",");	
    		
    		Console.WriteLine(input);
    		Console.WriteLine(output);
    		
    	}
    }
