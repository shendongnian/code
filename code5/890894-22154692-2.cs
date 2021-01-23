    public static T Replace<T>( this T[] list , Func<T,bool> isDesired , T replacement ) where T:class
    {
      T replacedItem = null ;
      for ( int i = 0 ; replacedItem == null && i < list.Length ; ++i )
      {
        T item = list[i] ;
        bool desired = isDesired(item) ;
        if ( desired )
        {
          replacedItem = item ;
          list[i]      = replacement ;
        }
      }
      return replacedItem ; // the replaced item or null if no replacements were made.
    }
