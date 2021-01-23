    public static void Test(Func<IList<int>, int, IEnumerable<IEnumerable<int>>> getVariations)
    {
      var max = 11;
      var timer = System.Diagnostics.Stopwatch.StartNew();
      for (int i = 1; i < max; ++i)
        for (int j = 1; j < i; ++j)
          getVariations(MakeList(i), j).Count();
      timer.Stop();
      Console.WriteLine("{0,40}{1} ms", getVariations.Method.Name, timer.ElapsedMilliseconds);
    }
    // Make a list that repeats to guarantee we have duplicates
    public static IList<int> MakeList(int size)
    {
      return Enumerable.Range(0, size/2).Concat(Enumerable.Range(0, size - size/2)).ToList();
    }
