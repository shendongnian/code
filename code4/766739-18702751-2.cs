    public static class StringExtensions {
        public static bool IsRegexMatch( this string s, string regex ) {
            return Regex.IsMatch( s, regex );
        }
        public static string RegexReplace( this string s, string regex, string replacement ) {
            return Regex.Replace( s, regex, replacement );
        }
        public static string RegexReplace( this string s, string regex, Func<string,string> replacement ) {
            return Regex.Replace( s, regex, 
                new MatchEvaluator( x => replacement(x.Value) ) );
        }
    }
