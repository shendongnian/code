    public static string SubstringBeforeTime(string input, string timeFormat = "HH:mm:ss")
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        DateTime time;
        if (input.Length == timeFormat.Length && DateTime.TryParseExact(input, timeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
        {
            return ""; // full text is time
        }
        char[] wordSeparator = {' ', '\t'};
        int lastIndex = 0;
        int spaceIndex = input.IndexOfAny(wordSeparator);
        if(spaceIndex == -1)
            return input;
        char[] chars = input.ToCharArray();
        while(spaceIndex >= 0)
        {
            int nonSpaceIndex = Array.FindIndex<char>(chars, spaceIndex + 1, x => !wordSeparator.Contains(x));
            if(nonSpaceIndex == -1)
                return input;
            string nextWord = input.Substring(lastIndex, spaceIndex - lastIndex);
            if( nextWord.Length == timeFormat.Length 
             && DateTime.TryParseExact(nextWord, timeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
                return input.Substring(0, lastIndex);
            }
            lastIndex = nonSpaceIndex;
            spaceIndex = input.IndexOfAny(wordSeparator, nonSpaceIndex + 1);
        }
        return input;
    }
