    static void CountBuckets<T>(HashSet<T> hashSet)
    {
        var field = typeof(HashSet<T>).GetField("m_buckets", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        var buckets = (int[])field.GetValue(hashSet);
        foreach (var index in buckets)
        {
            Console.WriteLine(index);
        }
        int numberOfBuckets = 0;
        int numberOfBucketsUsed = 0;
        if (buckets != null)
        {
            numberOfBuckets = buckets.Length;
            numberOfBucketsUsed = buckets.Where(i => i != 0).Count();
        }
        Console.WriteLine("Number of buckets: {0} / Used: {1}", numberOfBuckets, numberOfBucketsUsed);
    }
