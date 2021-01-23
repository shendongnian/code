    public static IPropagatorBlock<TSplit, TMerged>
        CreaterMergerBlock<TSplit, TMerged>(
        Func<TSplit, TMerged> getMergedFunc, Func<TMerged, int> getSplitCount)
    {
        var dictionary = new Dictionary<TMerged, int>();
        return new TransformManyBlock<TSplit, TMerged>(
            split =>
            {
                var merged = getMergedFunc(split);
                int count;
                dictionary.TryGetValue(merged, out count);
                count++;
                if (getSplitCount(merged) == count)
                {
                    dictionary.Remove(merged);
                    return new[] { merged };
                }
                dictionary[merged] = count;
                return new TMerged[0];
            });
    }
