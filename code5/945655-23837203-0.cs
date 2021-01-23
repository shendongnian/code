    public ConcurrentDictionary<string, int> CountOptions(int[] options)
    {
        ConcurrentDictionary<string, int> counts = new ConcurrentDictionary<string, int>();
        for (var t = 0; t < options.Length; t++)
        {
            counts.AddOrUpdate(options[t].ToString(), 1, (k, v) => v + 1);
        }
        return counts;
    }
