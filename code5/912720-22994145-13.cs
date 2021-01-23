    static TimeSpan PopulateDictionary(int[] input, int buckets)
    {
        int divisor = input.Length / buckets;
        int c1, c2;
        c1 = c2 = 0;
        var dictionary = new Dictionary<int, int>(buckets);
        var stopwatch = Stopwatch.StartNew();
        foreach (var item in input)
        {
            int key = item / divisor;
            int count;
            if (!dictionary.TryGetValue(key, out count))
            {
                dictionary.Add(key, 1);
                ++c1;
            }
            else
            {
                count++;
                dictionary[key] = count;
                ++c2;
            }
        }
        stopwatch.Stop();
        Console.WriteLine("{0}:{1}", c1, c2);
        return stopwatch.Elapsed;
    }
