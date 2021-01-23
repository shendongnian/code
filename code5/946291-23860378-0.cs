    public static string ToTitleCase(string input, int minLength = 0)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        string titleCaseDefault = ti.ToTitleCase(input);
        if (minLength == 0)
            return titleCaseDefault;
        StringBuilder sb = new StringBuilder(titleCaseDefault.Length);
        bool lookingForFirstNonSPace = true;
        int wordCount = 0;
        for (int i = 0; i < titleCaseDefault.Length; i++)
        {
            char c = titleCaseDefault[i];
            bool firstNonSpace = lookingForFirstNonSPace && !char.IsWhiteSpace(c);
            if (firstNonSpace)
            {
                wordCount++;
                int firstSpace = titleCaseDefault.IndexOfAny(new[] { ' ', '\t', '\n' }, i);
                int endIndex = firstSpace >= 0 ? firstSpace : titleCaseDefault.Length;
                string word = titleCaseDefault.Substring(i, endIndex - i);
                if(wordCount == 1) // first word upper
                    sb.Append(word);
                else
                    sb.Append(word.Length < minLength ? word.ToLowerInvariant() : ti.ToTitleCase(word));
                i = endIndex - 1;
            }
            else
                sb.Append(c);
        }
        return sb.ToString();
    }
