    static IEnumerable<int[]> EnumeratePermutations2(int[] ints)
    {
        Dictionary<int, int> intCounts = ints.GroupBy(n => n)
                                             .ToDictionary(g => g.Key, g => g.Count());
        int[] distincts = intCounts.Keys.ToArray();
        foreach (int[] permutation in EnumeratePermutations2(new int[0], intCounts, distincts))
            yield return permutation;
    }
    
    static IEnumerable<int[]> EnumeratePermutations2(int[] prefix, Dictionary<int, int> intCounts, int[] distincts)
    {
        foreach (int n in distincts)
        {
            int[] newPrefix = new int[prefix.Length + 1];
            Array.Copy(prefix, newPrefix, prefix.Length);
            newPrefix[prefix.Length] = n;
            yield return newPrefix;
            intCounts[n]--;
            int[] newDistincts = intCounts[n] > 0
                                 ? distincts
                                 : distincts.Where(x => x != n).ToArray();
            foreach (int[] permutation in EnumeratePermutations2(newPrefix, intCounts, newDistincts))
                yield return permutation;
            intCounts[n]++;
        }
    }
