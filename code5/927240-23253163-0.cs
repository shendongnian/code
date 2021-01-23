    static string PurgeRedundantExtensions( string fileName , params string[] extensions )
    {
      if ( string.IsNullOrWhiteSpace(fileName) ) throw new ArgumentNullException( "fileName"               ) ;
      if ( extensions.Length < 1               ) throw new ArgumentException(     "no extensions supplied" ) ;
      
      List<segments> segments      =  fileName.Split('.') ;
      int            last          =  segments.Length - 1 ;
      bool           hasRedundancy =  segments.Length > 2
                                   && extensions.Contains( segments[ last   ] , StringComparer.OrdinalIgnoreCase )
                                   && extensions.Contains( segments[ last-1 ] , StringComparer.OrdinalIgnoreCase )
                                   ;
      
      if ( hasRedundancy )
      {
        segments.RemoveAt(last) ;
      }
      
      string purged = string.Join( "." , segments ) ;
    }
