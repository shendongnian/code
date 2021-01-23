    static IEnumerable<IEnumerable<int>> EnumeratePermutations(int[] ints)
    {
        Dictionary<int, int> v2r = ints.Distinct()
                                       .OrderBy(n => n)
                                       .Select((n, i) => new { n, i })
                                       .ToDictionary(p => p.i + 1, p => p.n);
        Dictionary<int, int> r2v = v2r.ToDictionary(p => p.Value, p => p.Key);
        
        int vBase = v2r.Count + 1;
        int[] vInts = ints.Select(n => r2v[n])
                          .OrderBy(n => n)
                          .ToArray();
        Dictionary<int, int> vIntCounts = vInts.GroupBy(n => n)
                                               .ToDictionary(g => g.Key, g => g.Count());
    
        foreach (int i in Enumerable.Range(0, (int)Math.Pow(vBase, ints.Length)))
        {
            int v = i;
            List<int> vDigits = new List<int>();
            do
            {
                int vDigit = v % vBase;
                v /= vBase;
                vDigits.Add(vDigit);
            } while (v > 0);
            if (vDigits.All(n => n != 0) && vDigits.GroupBy(n => n).All(g => g.Count() <= vIntCounts[g.Key]))
            {
                vDigits.Reverse();
                yield return vDigits.Select(n => v2r[n]);
            }
        }
    }
