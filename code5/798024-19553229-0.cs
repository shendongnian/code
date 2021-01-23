    class My2TupleComparer : IComparer<Tuple<string,string>
    {
      public int Compare(Tuple<string,string> x, Tuple<string,string> y )
      {
        int cc ;
        if      ( x == null && y == null ) cc =  0 ;
        else if ( x == null && y != null ) cc = -1 ;
        else if ( x != null && y == null ) cc = +1 ;
        else /* ( x != null && y != null ) */
        {
          cc = string.Compare(x.Item1 , y.Item1 , StringComparison.OrdinalIgnoreCase ) ;
          if ( cc == 0 )
          {
            cc = String.Compare( x.Item2 , y.Item2 , StringComparison.OrdinalIgnoreCase ) ;
          }
        }
        return cc ;
      }
    }
