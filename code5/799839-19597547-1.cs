    struct Check
    {
      private int[] _x ;
      public int[] X { get { return _x ?? new int[3]{0,0,0,} ; } }
    }
