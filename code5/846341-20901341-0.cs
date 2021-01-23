    public static class StringExtensions
    {
        public static IEnumerable<int> AllIndexesOf(this string source, string substring)
        {
            int index = -1;
            while ((index = source.IndexOf(substring, index + 1)) >= 0)
                yield return index;
        }
    }
