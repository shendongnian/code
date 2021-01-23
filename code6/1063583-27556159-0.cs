    public static int[] Distribute(int total, int buckets)
    {
        if (total < 0) { throw new ArgumentException("cannot be less than 0", "total"); }
        if (buckets < 1) { throw new ArgumentException("cannot be less than 1", "buckets"); }
    
        var average = total / buckets;
        var remainder = total % buckets;
    
        var array = new int[buckets];
    
        for (var i = 0; i < buckets; i++)
        {
            array[i] = average + (i < remainder ? 1 : 0);
        }
    
        return array;
    }
