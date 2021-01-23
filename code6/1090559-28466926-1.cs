    public static IEnumerable<int> TextDigits( this TextBox instance )
    {
      int value = int.Parse(instance.Text) ;
      if ( value == 0 ) { yield return 0 ; }
      while ( value != 0 )
      {
        int d = value % 10 ;
        value /= 10 ;
        yield return d ;
      }
    }
