    public static class LinqExtensions
    {
      public static int? IndexOfOrNull<T>( this IEnumerable<T> list , Func<T,bool> isDesired  )
      {
        int  i       = 0     ;
        bool desired = false ;
        foreach ( T item in list )
        {
          desired = isDesired(item) ;
          if ( desired ) break ;
          ++i ;
        }
        return desired ? i : (int?)null ;
      }
      public static int IndexOf<T>( this IEnumerable<T> list , Func<T,bool> isDesired )
      {
        int? index = IndexOfOrNull( list , isDesired ) ;
        if ( !index.HasValue ) throw new InvalidOperationException() ;
        return index.Value ;
      }
    }
