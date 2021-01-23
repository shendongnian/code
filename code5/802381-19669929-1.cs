    private static readonly Regex rxWord = new Regex( @"\w+" ) ;
    static IEnumerable<string> ParseWords( string s )
    {
      return rxWord.Matches(s).Cast<Match>().Select( m => m.Value ) ;
    }
    
    private static Regex rxNonWord = new Regex( @"\W+" ) ;
    private static IEnumerable<string> ParseNonWords( string s )
    {
      return rxNonWord.Matches(s).Cast<Match>().Select( m => m.Value ) ;
    }
