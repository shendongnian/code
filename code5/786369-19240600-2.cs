    public class Rewriter
    {
        private readonly List<TokenOperation> _definitions = new List<TokenOperation>();
        public void AddPattern(string pattern, Func<string, string> mutator)
        {
            _definitions.Add(new TokenOperation(pattern, mutator));
        }
        public void AddLiteral(string pattern, string replacement)
        {
            AddPattern(Regex.Escape(pattern), x => replacement);
        }
        public string Rewrite(string value)
        {
            var workingValue = new List<UsageIndicator> { new UsageIndicator(value, false) };
            
            foreach (var definition in _definitions)
            {
                definition.Match(workingValue);
            }
            return string.Join("", workingValue);
        }
    }
