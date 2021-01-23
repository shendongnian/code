    public static int[] Initialize( this int[] instance , int value )
    {
      if ( instance == null ) throw new ArgumentNullException("instance") ;
      for ( int i = 0 ; i < instance.Length ; ++i )
      {
        instance[i] = value ;
      }
      return instance ;
    }
