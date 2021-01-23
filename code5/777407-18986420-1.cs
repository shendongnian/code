    public List<List<byte>> SplitToSublists(List<byte> source)
    {
        return source
                 .Select((x, i) => new { Index = i, Value = x })
                 .GroupBy(x => x.Index / 100)
                 .Select(x => x.Select(v => v.Value).ToList())
                 .ToList();
    }
