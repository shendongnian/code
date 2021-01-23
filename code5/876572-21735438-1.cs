    public class RegexCollection
    {
        private readonly Regex _allowOneSpace = new Regex(" ");
        
        public Regex AllowOneSpace { get { return _allowOneSpace; } }
    }
    
    public static class RegexExtensions
    {
        public static IEnumerable<string[]> SmartRegex(
            this IEnumerable<string> collection,
            Func<RegexCollection, Regex> selector
        )
        {
            var regexCollection = new RegexCollection();
            var regex = selector(regexCollection);
            return collection.Select(l => regex.Split(l));
        }
    }
