    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var subjectString = "hello:123,good:456,bye:789";
    		var result = Regex.Matches(subjectString, @"\d+");
    		foreach(var item in result)
    		{
    			Console.WriteLine(item);
    		}
    		
    	}
    }
