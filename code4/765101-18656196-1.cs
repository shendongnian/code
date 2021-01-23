    public string SplitLongWords(string text, int maxWordLength)
    {
        var result = new StringBuilder();
        int currentWordLength = 0;
        foreach (char c in text)
        {
            if (char.IsWhiteSpace(c))
            {
                currentWordLength = 0;
            }
            else if (currentWordLength == maxWordLength)
            {
                currentWordLength = 1;
                result.Append(' '); // Or .Append('-') to separate long words with '-'
            }
            else
            {
                ++currentWordLength;
            }
            result.Append(c);
        }
        return result.ToString().TrimEnd();
    }
