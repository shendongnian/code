    public static IEnumerable<string> Batch(IEnumerable<string> input, int batchSize)
    {
        int n = 0;
        var block = new List<string>();
        foreach (var line in input)
        {
            block.Add(line);
            if (++n != batchSize)
                continue;
            yield return string.Join("\n", block);
            block.Clear();
            n = 0;
        }
        if (block.Count > 0)
            yield return string.Join("\n", block);
    }
