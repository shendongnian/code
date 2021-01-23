    public static string toUpper( string s )
    {
      string value = null ;
      if ( s != null )
      {
        // match length 1: it's the first first character: upper-case it
        // match length 0: the last character isn't a period. append it
        value = rx.Replace( s.Trim() , m => m.Length == 1 ? m.Value.ToUpper( CultureInfo.InvariantCulture ) : "." ) ;
      }
      return value ;
    }
    static readonly Regex rx = new Regex( @"(^.)|($(?<=[^\.]" ) ;
