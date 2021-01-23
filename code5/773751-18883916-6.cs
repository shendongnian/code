    public static string StripNonDigits( string s )
    {
      return new StringBuilder(s.Length)
             .Append( s.Where( c => c >= '0' && c <= '9' ).ToArray() )
             .ToString()
             ;
    }
