    ConcurrentDictionary<BinaryPattern,int> concDict = new ConcurrentDictionary<BinaryPattern,int>();
    Parallel.Foreach(listOfDataSources, dataSource =>
    {
        for(int i=0;i<dataSource.OperationCount;i++)
        {
            BinaryPattern pattern = dataSource.GeneratePattern(i);
            concDict.AddOrUpdate(
                pattern,
                _ => 1, // if pattern doesn't exist - add with value "1"
                (_, previous) => previous + 1 // if pattern exists - increment existing value
            );
        }
    });
