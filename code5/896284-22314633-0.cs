    using System;
    using System.Collections.Generic;
    public class Test
    {
    	public static void Main()
    	{
    	
    		List<string> strings  = new List<string>();
    		strings.Add("110 - Main Road");
    		strings.Add("1104 - Main Road");
    		strings.Add("11088 - Main Road");
    		
    		foreach(string s in strings){
    			Console.WriteLine(s.Substring(0,s.IndexOf("-",0)));
    		
    		}
    	}
    }
