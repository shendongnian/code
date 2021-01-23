    public static class EXT
    {
       public static string GetByRegexMatch(this string st, string RegexPattern)
            {
                Regex txt = new Regex( RegexPattern , RegexOptions.IgnorePatternWhitespace);
                Match m = txt.Match(st);
                return m.Groups[0].Value;
            }
    
    }
