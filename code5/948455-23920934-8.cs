    static IEnumerable<int[]> EnumeratePermutations2(int[] ints)
    {
        Dictionary<int, int> intCounts = ints.GroupBy(n => n)
                                             .ToDictionary(g => g.Key, g => g.Count());
        foreach (int[] permutation in EnumeratePermutations2(new int[0], intCounts))
            yield return permutation;
    }
    
    static IEnumerable<int[]> EnumeratePermutations2(int[] prefix, Dictionary<int, int> intCounts)
    {
        int[] distincts = intCounts.Where(p => p.Value > 0).Select(p => p.Key).Distinct().ToArray();
        foreach (int n in distincts)
        {
            int[] newPrefix = new int[prefix.Length + 1];
            Array.Copy(prefix, newPrefix, prefix.Length);
            newPrefix[prefix.Length] = n;
            yield return newPrefix;
            intCounts[n]--;
            foreach (int[] permutation in EnumeratePermutations2(newPrefix, intCounts))
                yield return permutation;
            intCounts[n]++;
        }
    }
