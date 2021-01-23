    public int? ParseIntFromString( string s )
    {
      bool found = false ;
      int  acc   = 0 ;
      foreach( char c in s.Where( x => char.IsDigit )
      {
        found = true ;
        acc += c - '0' ;
      }
      return found ? (int?)acc : (int?) null ;
    }
      
