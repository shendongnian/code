    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication11
            {
                public static class Extension
                {
                    public static Match RegexMatch(this string input, string pattern, RegexOptions regexOptions = RegexOptions.IgnoreCase)
                    {
                        return Regex.Match(input, pattern, regexOptions);
                    }
                }
            }
        
