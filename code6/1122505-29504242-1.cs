    public static class StringExtensions
    {
        /// <summary>
        /// Replaces every odd straight quote with '„' and every even straight quote with '“'.
        /// </summary>
        /// <param name="source">The string acting as the source for replacements.</param>
        /// <returns>A string with replacements made.</returns>
        public static string ReplaceStraightQuotes(this string source)
        {
            var result = new StringBuilder(source);
            var lastIndex = source.IndexOf('"');
            int count = 0;
            while (lastIndex > -1)
            {
                char replaceQuote = (count++ % 2 == 0) ? '„' : '“';
                result.Replace('"', replaceQuote, lastIndex, 1);
                lastIndex = source.IndexOf('"', lastIndex + 1);
            }
            return result.ToString();
        }
    }
