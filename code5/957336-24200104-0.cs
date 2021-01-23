    using System; 
    using System.Text.RegularExpressions;
    namespace regex
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			string input = "Purse Balance: +0000504000 556080";
    
    	// Here we call Regex.Match.
    	Match match = Regex.Match(input, @"\+[0]*(\d+)",
    	    RegexOptions.IgnoreCase);
    
    	// Here we check the Match instance.
    	if (match.Success)
    	{
    	    // Finally, we get the Group value and display it.
    	    string key = match.Groups[1].Value;
    	    Console.WriteLine(key);
    	}
    		}
    	}
    }
