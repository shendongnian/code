    static void AppendPart(string pattern, int previousEndIndex, int endIndex, StringBuilder targetBuilder)
    {
        for (int i = previousEndIndex; i < endIndex; i++)
        {
            char c = pattern[i];
            if (c == '\\' && i < pattern.Length - 1 && pattern[i + 1] != '\\')
            {
                //backslash not followed by another backslash - it's an escape char
            }
            else
            {
                targetBuilder.Append(c);
            }
        }
    }
