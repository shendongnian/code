    public static IEnumerable<string> Batch(IEnumerable<string> input, int batchSize)
    {
        int n = 0;
        var block = new StringBuilder();
        foreach (var line in input)
        {
            block.AppendLine(line);
            if (++n != batchSize)
                continue;
            yield return block.ToString();
            block.Clear();
            n = 0;
        }
        if (n != 0)
            yield return block.ToString();
    }
