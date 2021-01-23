    private static readonly string[] Prefixes = {"ProjectDescription_", "Budget_", "CV_"};
    public static int PrefixIndex(string name)
    {
      for (int i = 0; i < Prefixes.Length; i++)
      {
        if (name.StartsWith(Prefixes[i]))
        {
          return i;
        }
      }
      return int.MaxValue;
    }
