    private static void Main()
    {
        var input1 = new[] {"1", "2", "3"};
        foreach (var output in EnumeratePermutations(input1))
            Debug.WriteLine(String.Join(",", output));
    }
    private static IEnumerable<T[]> EnumeratePermutations<T>(T[] input)
    {
        return from partCount in Enumerable.Range(1, input.Length)
                let inputs = (from i in Enumerable.Range(0, partCount) select input).ToArray()
                from productEntry in Crossjoin(inputs)
                where productEntry.Distinct().Count() == productEntry.Count()
                select productEntry;
    }
    private static IEnumerable<T[]> Crossjoin<T>(params T[][] inputs)
    {
        var indexer = new int[inputs.Length];
        var lastIncrementedIndex = inputs.Length - 1;
        while (lastIncrementedIndex >= 0)
        {
            yield return indexer.Select((n, i) => inputs[i][n]).ToArray();
            lastIncrementedIndex = inputs.Length - 1;
            while (lastIncrementedIndex >= 0)
            {
                ++indexer[lastIncrementedIndex];
                if (indexer[lastIncrementedIndex] == inputs[lastIncrementedIndex].Length)
                {
                    indexer[lastIncrementedIndex] = 0;
                    --lastIncrementedIndex;
                }
                else
                    break;
            }
        }
    }
 
