    public static class StringExtensions
    {
        public static IEnumerable<string> GetSubstrings(this string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("str must not be null or empty", "str");
            for (int c = 0; c < str.Length - 1; c++)
            {
                for (int cc = 1; c + cc <= str.Length; cc++)
                {
                    yield return str.Substring(c, cc);
                }
            }
        }
    }
