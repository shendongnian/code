    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		Regex r = new Regex(@"\d+");
    		string s = "grouped stuff 1-3";
    		
    		Match m = r.Match(s);
    		
    		while(m.Success) 
    		{
    			string matchText = m.Groups[0].Value;
    			Console.WriteLine(matchText);
    			m = m.NextMatch();
    		}	
    	}
    		
    }
