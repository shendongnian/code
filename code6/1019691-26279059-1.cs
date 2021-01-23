    private static Tuple<int, string> Process2(int value)
    {
      if (value == 4)
        throw new Exception("error 2");
      // do some processing
      return Tuple.Create(value, value * 3 + " good");
    }
    private static string Process3(Tuple<int, string> value)
    {
      return value.Item1 + " -> " + value.Item2;
    }
