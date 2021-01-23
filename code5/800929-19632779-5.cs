    public class SpecificationParser
    {
        public static ISpecification<int> Parse(string input)
        {
            var parts = input.Split(';');
            return parts.Aggregate(ParseSpec(parts[0]), 
                                   (spec, s) => spec.Or(ParseSpec(s)));
        }
        private static ISpecification<int> ParseSpec(string s)
        {
            var match = Regex.Match(s, @"\[(\d+)-(\d+)\]");
            if (match.Success)
            {
                int from = Int32.Parse(match.Groups[1].Value);
                int to = Int32.Parse(match.Groups[2].Value);
                return new RangeSpecification(from, to);
            }
            return new InSpecification(s.Split(',').Select(Int32.Parse).ToArray());
        }
    }
