    public List<List<byte>> DivideArray(List<byte> arr)
    {
        return arr
                 .Select((x, i) => new { Index = i, Value = x })
                 .GroupBy(x => x.Index / 100)
                 .Select(x => x.Select(v => v.Value).ToList())
                 .ToList();
    }
    
