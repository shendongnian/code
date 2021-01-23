    public static IEnumerable<int> TextDigits( this TextBox instance )
    {
      foreach( char c in instance.Text )
      {
        int d = c - '0' ;'
        if ( d >= 0 && d <= 9 ) yield return value ;
      }
    }
