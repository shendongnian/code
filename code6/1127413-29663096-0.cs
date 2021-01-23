    public static class StringExtenstions
    {
        public static string RegExAwesomeReplace(this string inputString,string searchPattern,string replacePattern)
        {
            Match searchMatch = Regex.Match(inputString,searchPattern);
            Match replaceMatch = Regex.Match(inputString, replacePattern);
            if (!searchMatch.Success || !replaceMatch.Success)
            {
                return inputString;
            }
            return inputString.Replace(searchMatch.Value, replaceMatch.Value);
        }
    }
