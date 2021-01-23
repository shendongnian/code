    static readonly Regex regex = new Regex(@"\([^\(^\).]*(?<bracket>\([^\(^\).]+\))[^\(^\).]*\)");
    
    static string ReplaceInnerParens(Match match)
    {
    	return match.Value.Replace(match.Groups["bracket"].Value, "[" + match.Groups["bracket"].Value.Substring(1, match.Groups["bracket"].Value.Length - 2) + "]");
    }
    
    static string Replace(string input)
    {
    	return regex.Replace(input, new MatchEvaluator(ReplaceInnerParens));
    }
    
    void Main() {
    	Console.WriteLine(Replace("This is (a test) of (something (cool like) this and) stuff like ((that and) stuff) yeah."));
    }
