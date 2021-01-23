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
          {
            b = true;
            x = ExpensiveComputation();
          }
        }
      }
      return x;
    }
