    public static class StringExtensions {
        public static string RegexReplace( this string s, string regex, string replacement ) {
            return Regex.Replace( s, regex, replacement );
        }
    }
