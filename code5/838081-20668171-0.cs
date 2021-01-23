    string Tidy( string s )
    {
      StringBuilder sb = new StringBuilder( s.Length ) ;
      
      foreach ( char c in s )
      {
        bool isAlpha =  ( c >= 'a' && c <= 'z' )
                     || ( c >= 'A' && c <= 'Z' )
                     ;
        sb.Append( isAlpha ? c : ' ' ) ;
      }
            
      return sb.ToString() ;
    }
