    public static string ToUpperUntilNthOccurrenceOfChar(string text, char c, int occurrences)
    {
        if (occurrences > text.Count(x => x == c))
        {
            return text.ToUpper();
        }
    
        int index = 0;
        for (int i = 0; i < occurrences; i++, index++)
        {
            index = text.IndexOf(c, index);
        }
        return text.Substring(0, index).ToUpper() + text.Substring(index);
    }
