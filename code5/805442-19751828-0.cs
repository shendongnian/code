    public static class Extensions
    {
        private List<string> _words = new List<string> { "abc", "def", "ghi" };
        public static bool ContainsWords(this string s)
        {
            return _words.Any(w => s.Contains(w));
        }
        public static bool ContainsWords(this string s, List<string> words)
        {
            return words.Any(w => s.Contains(w));
        }
    }
