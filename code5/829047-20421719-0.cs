    public static class StringExtensions
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace(str, @"[^\w\d\s]", "");
        }
    }
