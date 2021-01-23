    static void Main(string[] args)
    {
        var test = new List<Tuple<string, int[]>>();
    
        test.Add(new Tuple<string, int[]>("a", new int[] { 1, 4, 7, 8 })); //item 1
        test.Add(new Tuple<string, int[]>("a", new int[] { 1, 2, 6, 5 })); //item 2
        test.Add(new Tuple<string, int[]>("a", new int[] { 1, 2, 6  })); //item 2
        test.Add(new Tuple<string, int[]>("a", new int[] { 1, 2,  5 })); //item 2
        test.Add(new Tuple<string, int[]>("a", new int[] { 1,  6, 5 })); //item 2
        test.Add(new Tuple<string, int[]>("a", new int[] {  2, 6, 5 })); //item 2
        test.Add(new Tuple<string, int[]>("b", new int[] { 1, 2, 3, 4 })); //item 4
        test.Add(new Tuple<string, int[]>("a", new int[] { 1, 1, 4, 9 })); //item 5
    
        var result = test.OrderBy(x => x,new CustomComp()) ;
        
        result.Dump();
    }
    
    
    public class CustomComp : IComparer<Tuple<string, int[]>>
    {
       public int Compare(Tuple<string, int[]> x,Tuple<string, int[]> y)
       {
         int strR = string.Compare(x.Item1,y.Item1);
         if (strR == 0)
           return x.Item2.SequenceCompare(y.Item2);
         else
         return strR;
       }
    }
    
    static class Compare
    {
      public static int SequenceCompare<TSource>(this IEnumerable<TSource> x, IEnumerable<TSource> y)
      {
        return SequenceCompare(x,y,System.Collections.Generic.Comparer<TSource>.Default);
      }
    
      public static int SequenceCompare<TSource>(this IEnumerable<TSource> x, IEnumerable<TSource> y, IComparer<TSource> comparer)
      {
        if (x == null) throw new ArgumentNullException("x");
        if (y == null) throw new ArgumentNullException("y");
            
        using (IEnumerator<TSource> xe = x.GetEnumerator(), ye = y.GetEnumerator())
        {
          while (true)
          {
            bool next1 = xe.MoveNext();
            bool next2 = ye.MoveNext();
           
            // Are not of same length. longer one >
            if (next1 != next2)
            {
                if (next1 == true) return 1;
                return -1;
            }
            
            // Both finished -- equal
            if (!next1) return 0;
                    
            int result = comparer.Compare(xe.Current, ye.Current);
            
            if (result != 0) return result;
          } 
        }
      }
    } 
