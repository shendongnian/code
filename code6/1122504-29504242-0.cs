    public static class StringExtensions
    {
        /// <summary>
        /// Replaces every odd straight quote with '„' and every even straight quote with '“'.
        /// </summary>
        /// <param name="source">The string acting as the source for replacements.</param>
        /// <returns>A string with replacements made.</returns>
        public static string ReplaceStraightQuotes(this string source)
        {
            var result = source;
            if (result != null)
            {
                var lastIndex = result.IndexOf('"');
                int count = 0;
                while (lastIndex > -1)
                {
                    char replaceQuote = (count++ % 2 == 0) ? '„' : '“';
                    result = result.Substring(0, lastIndex) + replaceQuote + result.Substring(lastIndex + 1);
                    lastIndex = result.IndexOf('"', lastIndex + 1);
                }
            }
            return result;
        }
    }
