    public static string FirstWord( this string s )
    {
      if ( s == null ) throw new ArgumentNullException("s");
      int i = 0 ;
      while ( i < s.Length && !char.isWhiteSpace(s[i]) )
      {
        ++i ;
      }
      if ( i == 0 ) throw new InvalidOperationException("no word found");
      return s.Substring(0,i);
    }
