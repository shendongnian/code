    private string Emoticonize(string originalStr)
    {
        StringBuilder RegExString = new StringBuilder(@"(?<=^|\s)(?:");
        foreach (KeyValuePair<string, string> e in Emoticons)
        {
            RegExString.Append(Regex.Escape(e.Key) + "|");
        }
        RegExString.Replace("|", ")", RegExString.Length - 1, 1);
        RegExString.Append(@"(?=$|\s)");
        MatchCollection EmoticonsMatches = Regex.Matches(originalStr, RegExString.ToString());
    
        RegExString.Clear();
        RegExString.Append(originalStr);
        for (int i = EmoticonsMatches.Count - 1; i >= 0; i--)
        {
            RegExString.Replace(EmoticonsMatches[i].Value, Emoticons[EmoticonsMatches[i].Value], EmoticonsMatches[i].Index, EmoticonsMatches[i].Length);
        }
    
        return RegExString.ToString();
    }
