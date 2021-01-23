    static Func<int> Natural()
    {
      return() => { int seed = 0; return seed++; };
    }
    
    static void Main()
    {
      Func<int> natural = Natural();
      Console.WriteLine (natural());           // 0
      Console.WriteLine (natural());           // 0
    }
