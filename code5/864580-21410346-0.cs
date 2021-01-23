    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string pattern = @"ID\s?\:\s(?<id>\w+).+Quantity\s?\:\s(?<quantity>\d+).+each\s?\:\s(?<points>\d+)";
    		string input = "Tumbler (ID: AGST, Quantity: 1, Points each: 2)";
    		
    		Regex regex = new Regex(pattern);
    		Match m = regex.Match(input);
    		
    		if(m.Success)
    		{
    			string id = m.Groups["id"].Value;
    			int quantity = Int32.Parse(m.Groups["quantity"].Value);
    			int points = Int32.Parse(m.Groups["points"].Value);
    			
    			Console.WriteLine(id + ", " + quantity + ", " + points);
    		}
    	}
    }
