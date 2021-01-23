    class ArrayComparer : IComparer<int[]>
    {
      public int Compare(int[] x, int[] y)
      {
        for (var i = 0; i < x.Length && i < y.Length; i++)
        {
          if (x[i] > y[i])
            return 1;
          if (y[i] > x[i])
            return -1;
        }
        if (y.Length > x.Length)
          return -1;
        else if (y.Length < x.Length)
          return 1;
        return 0;
      }
    }
