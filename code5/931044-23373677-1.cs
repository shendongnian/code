    public static string toUpper( string s )
    {
      if ( s == null ) return null ;
      StringBuilder sb = new StringBuilder( s.Trim() ) ;
      if ( sb.Length > 0 )
      {
        sb[0] = char.ToUpper(sb[0] , CultureInfo.InvariantCulture ) ;
        if ( sb[ sb.Length-1] != '.' ) sb.Append('.') ;
      }
      value = sb.ToString() ;
      return value ;
    }
