        List<Tuple<string, int>> list = new List<Tuple<string, int>>();
        list.Add(Tuple.Create<string, int>("dog", 25));
        list.Add(Tuple.Create<string, int>("dog", 10));
        list.Add(Tuple.Create<string, int>("cat", 5));
        list.Add(Tuple.Create<string, int>("cat", 7));
        list.Add(Tuple.Create<string, int>("other", 4));
        Dictionary<string, int> dic = list.
         GroupBy(t => t.Item1).
         Where(grp => grp.Count() > 1).
         ToDictionary(grp => grp.Key,
                      grp => grp.Select(tuple => tuple.Item2).Aggregate((a, b) => a * b));
