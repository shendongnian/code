    public IList<DifferenceFooObject> RunPropComparison(List<FooObject> foos)
    {
        return foos.GroupBy(x => x.Test1)
          .Select(g => new DifferenceFooObject(g.Key, g.SelectMany(x => x.SubTest1)))
          .ToList();
    }
