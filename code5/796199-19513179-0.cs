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
            foreach (Capture c1 in GetCaptures(m, "singlelinedata", m.Index, m.Index + m.Length))
            {
                int lineStart = c1.Index;
                int lineEnd = c1.Index + c1.Length;
                
                var result = new Result();
                result.Line = int.Parse(GetCaptures(m, "line", lineStart, lineEnd).First().Value);
                result.MeasureLine = int.Parse(GetCaptures(m, "measureline", lineStart, lineEnd).First().Value);
                
                result.SamplingPoints = new List<int>();
                foreach (Capture c2 in GetCaptures(m, "samplingpoint", lineStart, lineEnd))
                {
                    result.SamplingPoints.Add(int.Parse(c2.Value));
                }
                
                yield return result;
            }
        }
    }
    
    IEnumerable<Capture> GetCaptures(Match match, string groupName, int startIndex, int endIndex)
    {
        foreach (Capture c in match.Groups[groupName].Captures)
        {
            if (c.Index < startIndex) continue;
            if (c.Index >= endIndex) break;
            
            yield return c;
        }
    }
