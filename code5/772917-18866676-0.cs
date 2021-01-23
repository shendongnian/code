    public static class StringExtensions
    {
        public static string EscapeBraces(this string s)
        {
            return s.Replace("{", "{{")
                    .Replace("}", "}}");
        }
    }
    f(SomeJson.EscapeBraces() + "{0}");
