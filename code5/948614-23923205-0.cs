    public static IEnumerable<KeyValuePair<int,T[]>> Partition<T>( this IEnumerable<T> source , int partitionSize )
    {
      if ( source        == null ) throw new ArgumentNullException("source") ;
      if ( partitionSize <  1    ) throw new ArgumentOutOfRangeException("partitionSize") ;
      
      int     i         = 0 ;
      List<T> partition = new List<T>( partitionSize ) ;
      
      foreach( T item in source )
      {
        partition.Add(item) ;
        if ( partition.Count == partitionSize )
        {
          yield return new KeyValuePair<int,T[]>( ++i , partition.ToArray() ) ;
          partition.Clear() ;
        }
      }
      // return the last partition if necessary
      if ( partition.Count > 0 )
      {
        yield return new Partition<int,T>( ++i , items.ToArray() ) ;
      }
    }
