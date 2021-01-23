    class MatchRef
    {
        public MatchCollection match;
    }
    public static boolean tryRegMatch(MatchRef matchRef, string input, string pattern)
    {   
        matchRef.match = Regex.Matches(input, pattern);
        return (matchRef.match.Count > 0);
    }
