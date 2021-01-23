    class StringExtensions
    {
        public static string JoinNonEmpty(string separator, IEnumerable<string> values)
        {
            return string.Join(separator, values.Where(s => !string.IsNullOrEmpty(s)));
        }
        public static string JoinNonEmpty(string separator, params object[] values)
        {
            return string.Join(separator, values.Where(s => !string.IsNullOrEmpty(s.ToString())));
        }
    }
