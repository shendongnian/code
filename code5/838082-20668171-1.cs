    string Tidy( string s )
    {
      StringBuilder sb = new StringBuilder( s.Length ) ;
      
      foreach ( char c in s )
      {
        bool isLowerCase = ( c >= 'a' && c <= 'z' ) ;
        bool isUpperCase = ( c >= 'A' && c <= 'Z' ) ;
        bool isAlpha     = isLowerCase || isUpperCase ;
        sb.Append( isAlpha ? c : ' ' ) ;
      }
            
      return sb.ToString() ;
    }
