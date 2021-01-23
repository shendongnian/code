    public static class StringExtensions
    {
        public static string SubstringRegion(this string str, int startIndex, int endIndex)
        {
            return str.Substring(startIndex, endIndex - startIndex + 1);
        }
    }
