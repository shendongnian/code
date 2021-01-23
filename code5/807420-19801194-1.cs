    static bool HasBadData( double[,] doubles )
    {
      bool hasBadData = false ;
      for ( int i = 0 ; !hasBadData && i < doubles.GetLength(0) ; ++i )
      {
        for ( int j = 0 ; !hasBadData && j < doubles.GetLength( 1 ) ; ++j )
        {
          double d = doubles[i,j] ;
          hasBadData = double.IsInfinity(d) || double.IsNaN(d) ;
        }
      }
      return hasBadData ;
    }
