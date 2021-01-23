    public MyDictionary(IReadOnlyDictionary<MyEnum, double> source)
    {
      foreach (var pair in source)
        base.Add(pair.Key, pair.Value);
    }
