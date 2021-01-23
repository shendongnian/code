    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string result = Regex.Replace("This is a test to see if DOMAIN gets replaced properly. DOMAIN", "(?<myName>DOMAIN)", "<a>${myName}</a>");
    		
    		result.Dump();
    	}
    }
