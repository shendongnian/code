    public static class StringExt
    {
        public static bool ContainsInvariant(this string sourceString, string filter)
        {
            return sourceString.Any(c=>filter.Contains(c));
        }
    }
