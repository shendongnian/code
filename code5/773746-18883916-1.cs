    public static string StripNonDigits( string s )
    {
      StringBuilder sb = new StrigBuilder(s.Length) ;
      foreach ( char c in s )
      {
        if ( !char.IsDigit(c) ) continue ;
        sb.Append(c) ;
      }
      return sb.ToString() ;
    }
