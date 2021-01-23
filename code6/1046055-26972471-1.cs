    //Based on:
    
    //.NET 4.5
    
    //Program that uses Match, Regex: C#
    
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    		String subject = "ABC123456DEF\n123456\nABC123456\n123456DEF"
    		Regex regex = new Regex(@"([a-zA-Z]+)|([0-9]+)");
    		foreach (Match match in regex.Matches(subject))
    		{
    			MessageBox.Show(match.Value);
    		}
        }
    }
