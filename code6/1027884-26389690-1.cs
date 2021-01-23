    static class Extensions
    {
        public static IEnumerable<String> SplitParts(this string text, int length)
        {
            for (var i = 0; i < text.Length; i += length)
                yield return text.Substring(i, Math.Min(length, text.Length - i));
        }
    }
