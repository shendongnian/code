    public sealed class Finder
    {
        private readonly string _match;
        public Finder(string match)
        {
            _match = match.ToLower();
        }
        public bool Match(string s)
        {
            return ((s.Length > 5) && (s.Substring(0, 7).ToLower() == _match));
        }
    }
