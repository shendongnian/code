    static List<int> GenerateList(int size, int numOfTasks)
    {
        return Enumerable.Range(0, size)
            .AsParallel()
            .WithDegreeOfParallelism(numOfTasks)
            .Select(_ => Rand.Value.Next())
            .ToList();
    }
