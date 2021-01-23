    public static class StringExtensions
    {
        public static string SubstringAfter(this string str, string sequence)
        {
            return str.Substring(str.IndexOf(sequence) + 1);
        }
    }
