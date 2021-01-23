    static List<int> SumOfLists( params List<int>[] lists )
    {
      return SumOfLists( (IEnumerable<List<int>>) lists ) ;
    }
    static List<int> SumOfLists( IEnumerable<List<int>> lists )
    {
      List<int> result = new List<int>() ;
      
      foreach ( List<int> list in lists )
      {
        
        for( int j = 0 ; j < list.Count ; ++j )
        {
          int value = list[j] ;
          if ( j < result.Count )
          {
            result[j] += value ;
          }
          else
          {
            result.Add( value ) ;
          }
          
        } // end for-j
        
      } // end for-each
      
      return result ;
    }
