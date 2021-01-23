    //Sadly, we can't extend the Regex class
    public class RegExp
    {
    	//usage : RegExp.Filter("50% of 50% is 25%", @"[0-9]+\%")
    	public static string Filter(string input, string pattern)
    	{
    		return Regex.Matches(input, pattern).Cast<Match>()
    			.Aggregate(string.Empty, (a,m) => a += m.Value);
    	}
    }
    
    public static class StringExtension
    {
    	//usage : "50% of 50% is 25%".Filter(@"[0-9]+\%")
    	public static string Filter(this string input, string pattern)
    	{
    		return Regex.Matches(input, pattern).Cast<Match>()
    			.Aggregate(string.Empty, (a,m) => a += m.Value);
    	}
    }
