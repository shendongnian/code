    struct Pair<T>
    {
      public T First { get; private set; }
      public T Second { get; private set; }
      public Pair(T first, T second) : this()
      {
        First = first;
        Second = second;
      }
    }
    ...
    static IEnumerable<Pair<int>> Values()
    {
      int i = 0;
      while(true)
      {
        yield return new Pair<int>(functionCall(), i);
        i = i + 1;
      }
    }
    ...
    List<Pair<int>> pairs = Values().Take(50).OrderBy(p=>p.First).ToList();
