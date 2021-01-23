    void Main()
    {
        string data = @"SENT KV L1 123 1 2 3 L2 456 4 5 6";
        Parse(data).Dump();
    }
    
    public class Result
    {
        public int Line;
        public int MeasureLine;
        public List<int> SamplingPoints;
    }
    
    private Regex pattern = new Regex(@"^SENT KV(?<singlelinedata> L(?<line>[1-9]\d*) (?<measureline>\d+)(?: (?<samplingpoint>\d+))+)+$", RegexOptions.Multiline);
    
    public IEnumerable<Result> Parse(string data)
    {
        foreach (Match m in pattern.Matches(data))
        {
            foreach (Capture c1 in m.Groups["singlelinedata"].Captures)
            {
                int lineStart = c1.Index;
                int lineEnd = c1.Index + c1.Length;
                
                var result = new Result();
                result.Line = int.Parse(m.Groups["line"].CapturesWithin(c1).First().Value);
                result.MeasureLine = int.Parse(m.Groups["measureline"].CapturesWithin(c1).First().Value);
                
                result.SamplingPoints = new List<int>();
                foreach (Capture c2 in m.Groups["samplingpoint"].CapturesWithin(c1))
                {
                    result.SamplingPoints.Add(int.Parse(c2.Value));
                }
                
                yield return result;
            }
        }
    }
    
    public static class RegexExtensions
    {
        public static IEnumerable<Capture> CapturesWithin(this Group group, Capture capture)
        {
            foreach (Capture c in group.Captures)
            {
                if (c.Index < capture.Index) continue;
                if (c.Index >= capture.Index + capture.Length) break;
                
                yield return c;
            }
        }
    }
