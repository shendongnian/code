    public class TokenOperation
    {
        public Regex Pattern { get; private set; }
        public Func<string, string> Mutator { get; private set; }
        public TokenOperation(string pattern, Func<string, string> mutator)
        {
            Pattern = new Regex(pattern);
            Mutator = mutator;
        }
        private List<UsageIndicator> ExtractRegions(string source, int index, int length, out int matchedIndex)
        {
            var result = new List<UsageIndicator>();
            var head = source.Substring(0, index);
            matchedIndex = 0;
            if (head.Length > 0)
            {
                result.Add(new UsageIndicator(head, false));
                matchedIndex = 1;
            }
            var body = source.Substring(index, length);
            body = Mutator(body);
            result.Add(new UsageIndicator(body, true));
            var tail = source.Substring(index + length);
            if (tail.Length > 0)
            {
                result.Add(new UsageIndicator(tail, false));
            }
            return result;
        }
        public void Match(List<UsageIndicator> source)
        {
            for (var i = 0; i < source.Count; ++i)
            {
                if (source[i].IsUsed)
                {
                    continue;
                }
                var value = source[i];
                var match = Pattern.Match(value.Value);
                if (match.Success)
                {
                    int modifyIBy;
                    source.RemoveAt(i);
                    var regions = ExtractRegions(value.Value, match.Index, match.Length, out modifyIBy);
                    for (var j = 0; j < regions.Count; ++j)
                    {
                        source.Insert(i + j, regions[j]);
                    }
                    i += modifyIBy;
                }
            }
        }
    }
