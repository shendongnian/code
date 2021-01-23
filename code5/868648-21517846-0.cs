     private static Regex regexRegex = new Regex("\\[(?<From>\\d)-(?<To>\\d)]", RegexOptions.Compiled);
        private static IEnumerable<string> GetStringsForRegex(string pattern)
        {
            var strings = Enumerable.Repeat("", 1);
            var lastIndex = 0;
            foreach (Match m in regexRegex.Matches(pattern))
            {
                if (m.Index > lastIndex)
                {
                    var capturedLastIndex = lastIndex;
                    strings = strings.Select(s => s + pattern.Substring(capturedLastIndex, m.Index - capturedLastIndex));
                }
                int from = int.Parse(m.Groups["From"].Value);
                int to = int.Parse(m.Groups["To"].Value);
                if (from > to)
                {
                    throw new InvalidOperationException();
                }
                strings = strings.SelectMany(s => Enumerable.Range(from, to - from + 1), (s, i) => s + i.ToString());
                lastIndex = m.Index + m.Length;
            }
            if (lastIndex < pattern.Length)
            {
                 var capturedLastIndex = lastIndex;
                 strings = strings.Select(s => s + pattern.Substring(capturedLastIndex));
            }
            return strings;
        }
