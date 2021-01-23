    static class Extensions
    {
      public static IEnumerable<BitSet> Choose(this BitSet b, int choose)
      {
        if (choose == 0) 
        { 
          yield return BitSet.Empty;
        }
        else
        {
          BitSet r = b;
          foreach(int item in b)
          {
            r = r.Remove(item);
            foreach(BitSet p in r.Choose(choose-1))
            {
              yield return p.Add(item);
            } 
          }
        }
      }
    } 
