    static object sync = new object();
    static bool b = false;
    static int x = 0;
    static int GetIt()
    {
      if (!b)
      {
        lock(sync)
        {
          if (!b)
            x = ExpensiveComputation();
        }
      }
      return x;
    }
