    public static int[] DistributeLinq(int total, int buckets)
    {
        if (total < 0) { throw new ArgumentException("cannot be less than 0", "total"); }
        if (buckets < 1) { throw new ArgumentException("cannot be less than 1", "buckets"); }
    
        var average = total / buckets;
        var remainder = total % buckets;
    
        return Enumerable.Range(1, buckets)
                         .Select(v => average + (v <= remainder ? 1 : 0))
                         .ToArray();
    }
