    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class P
    {
      static IEnumerable<int> F()
      {
        yield return 1;
        yield return 1;
        foreach(int i in F().Zip(F().Skip(1), (a,b)=>a+b))
          yield return i;
      }
    
      static void Main()
      {
        foreach(int i in F().Take(10))
          Console.WriteLine(i);
      }
    }
