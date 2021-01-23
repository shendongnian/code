    void Main()
    {
        var rangesInput = new[]
        {
            "123-456",
            "400-191",
        };
    
        var ranges = (from x in rangesInput
                      let s = x.Split('-')
                      select new Range(long.Parse(s[0]), long.Parse(s[1])))
                    .Aggregate(new List<Range>(), (agg, range) =>
                    {
                        var intersecting = agg.FirstOrDefault(r => range.Intersects(r));
    
                        if (intersecting != null)
                        {
                            intersecting.UnionWith(range);
                        }
                        else
                        {
                            agg.Add(range);
                        }
    
                        return agg;
                    });
        ranges.Dump();
    }
    
    class Range
    {
        public Range(long end1, long end2)
        {
            Start = Math.Min(end1, end2);
            End = Math.Max(end1, end2);
        }
    
        public long Start { get; private set; }
        public long End { get; private set; }
    
        public bool Intersects(Range range) => Math.Max(range.Start, Start) <= Math.Min(range.End, End);
    
        public void UnionWith(Range range)
        {
            Start = Math.Min(Start, range.Start);
            End = Math.Max(End, range.End);
        }
    }
