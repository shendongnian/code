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
        int[] vIntCounts = new[] { 0 }.Concat(vInts.GroupBy(n => n)
                                                   .OrderBy(g => g.Key)
                                                   .Select(g => g.Count()))
                                      .ToArray();
    
        foreach (int i in Enumerable.Range(0, (int)Math.Pow(vBase, ints.Length)))
        {
            int[] vIntCountsClone = vIntCounts.ToArray();
            int v = i;
            List<int> vDigits = new List<int>();
            bool isValid = true;
            do
            {
                int vDigit = v % vBase;
                if (--vIntCountsClone[vDigit] < 0)
                {
                    isValid = false;
                    break;
                }
                v /= vBase;
                vDigits.Add(vDigit);
            } while (v > 0);
            if (!isValid)
                continue;
            yield return vDigits.Select(n => v2r[n]);
        }
    }
