    public static IEnumerable<string> TakeUntilDupesLimitReached( this IEnumerable<string> source , int limit , StringComparison comparisonType )
    {
      if ( limit < 1 ) throw new ArgumentOutOfRangeException("limit") ;
      
      string p = null ;
      int    n = 0 ;
      
      foreach ( string s in source )
      {
        bool areEqual = s.Equals( p ?? s , comparisonType ) ;
        
        n = 1 + ( areEqual ? n : 0 ) ;
        p = s ;
        
        yield return s ;
        
        if ( n >= limit ) break ;
      }
      
    }
