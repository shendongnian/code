    File.ReadLines("example.txt")
        .Where(x => x.StartsWith("1") || x.StartsWith("7"))
        .Select((l, i) => new {Index = i, Line = l})
        .GroupBy(o => o.Index / 2, o => o.Line)
        .Select(g => new Test(g));
    public struct Test
    {
        public Test(IEnumerable<string> src) 
        { 
            var tmp = src.ToArray();
            Line1 = tmp.Length > 0 ? tmp[0] : null;
            Line2 = tmp.Length > 1 ? tmp[1] : null;
        }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
