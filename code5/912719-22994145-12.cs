    static TimeSpan PopulateDictionary1(int[] input, int buckets)
    {
        int divisor = input.Length / buckets;
        var dictionary = new Dictionary<int, int>(buckets);
        var stopwatch = Stopwatch.StartNew();
        foreach (var item in input)
        {
            int key = item / divisor;
            int count;
            dictionary.TryGetValue(key, out count);
        }
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
