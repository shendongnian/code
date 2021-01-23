    public static bool IsNullOrCLanguageWhitespace( this string s )
    {
      bool value = ( s == null || rxWS.IsMatch(s) ) ;
      return value ;
    }
    private static Regex rxWS = new Regex( @"^[ \t\n\v\f\r]*$") ;
