    static bool Merge(ref List<List<int>> source)
    {
        var merged = 0;
        var results = new List<List<int>>();
        foreach (var l in source)
        {
            var i = results.FirstOrDefault(x => x.Intersect(l).Any());
            if (i != null)
            {
                i.AddRange(l);
                merged++;
            }
            else
            {
                results.Add(l.ToList());
            }
        }
        source = results;
        return merged > 0;
    }
