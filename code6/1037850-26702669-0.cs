    var results = listOfDataSources.Select(dataSource =>
        Tuple.Create(dataSource, new Dictionary<BinaryPattern, int>())).ToList();
    Parallel.ForEach(results, result =>
    {
        for(int i = 0; i < result.Item1.OperationCount; i++)
        {
            BinaryPattern pattern = result.Item1.GeneratePattern(i);
            int count;
            result.Item2.TryGetValue(pattern, out count);
            result.Item2[pattern] = count + 1;
        }
    });
    var finalResult = new Dictionary<BinaryPattern, int>();
    foreach (result in results)
    {
        foreach (var kvp in result.Item2)
        {
            int count;
            finalResult.TryGetValue(kvp.Key, out count);
            finalResult[kvp.Key] = count + kvp.Value;
        }
    }
