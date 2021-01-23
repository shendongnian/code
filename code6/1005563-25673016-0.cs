    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		String url = @"Lists/Versions/2_.000";
            String pattern = @"\D+";
    
            string[] substrings = Regex.Split(url, pattern);    
            
            Console.WriteLine("'{0}'", substrings[1]);
            
    	}
    }
