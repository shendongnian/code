    public static class TextHelper
    {
        public static string Between(this string input, string start, string end, StringComparison comparison)
        {
            var startIndex = input.IndexOf(start, comparison);
            if (startIndex < 0)
                return null;
            startIndex += start.Length;
            var endIndex = input.IndexOf(end, startIndex, comparison);
            if (endIndex < 0)
                return null;
            return input.Substring(startIndex, endIndex - startIndex);
        }
    }
