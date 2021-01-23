    public static int GetMinNumber(int generations) {
      if (generations < 0)
        throw new ArgumentOutOfRangeException("generations");
      // Memoization will be quite good here
      // but since it takes about 1 second (on my computer) to solve the problem
      // and it's a throwaway code (all you need is a number "1979515")
      // I haven't done the memoization
      for (int result = 1; ; ++result) {
        int n = result;
        int itterations = 0;
        while (n != 1) {
          n = (n % 2) == 0 ? n / 2 : 3 * n + 1;
          itterations += 1;
          if (itterations > generations)
            break;
        }
        if (itterations == generations)
          return result;
      }
    }
    ...
    int test1 = GetMinNumber(8);   // <- 6
    int test2 = GetMinNumber(500); // <- 1979515
