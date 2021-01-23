    // using System.Linq;
    
    String url = @"Lists/Versions/2_.000";
    String pattern = @"(?<=/)\d+";
    
    string[] substrings = Regex.Matches(url, pattern)
                               .Cast<Match>()
    						   .Select(_ => _.Value)
    						   .ToArray();    
    foreach (string match in substrings)
    {
    	Console.WriteLine("'{0}'", match);
    }
