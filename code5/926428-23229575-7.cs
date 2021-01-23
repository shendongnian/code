    private static void Main()
    {
        var input1 = new[] {"1", "2", "3"};
        foreach (var output in EnumeratePermutations(input1))
            Debug.WriteLine(String.Join(",", output));
    }
    private static IEnumerable<T[]> EnumeratePermutations<T>(T[] input)
    {
        return from partCount in Enumerable.Range(1, input.Length)
                let inputs = Enumerable.Repeat(input, partCount).ToArray()
                from indices in EnumerateCrossjoinIndices(inputs)
                where indices.Distinct().Count() == indices.Length
                select indices.Select(n => input[n]).ToArray();
    }
    private static IEnumerable<int[]> EnumerateCrossjoinIndices(params Array[] arrays)
    {
        var arrayCount = arrays.Length;
        if (arrayCount == 0)
            yield break;
        if (arrays.Any(a => a.Length == 0))
            yield break;
        var indexer = new int[arrayCount];
            
        yield return (int[]) indexer.Clone();
        for (var dimension = arrayCount - 1; dimension >= 0; --dimension)
        {
            ++indexer[dimension];
            if (indexer[dimension] == arrays[dimension].Length)
                indexer[dimension] = 0;
            else
            {
                yield return (int[]) indexer.Clone();
                dimension = arrayCount;
            }
        }
    }
 
