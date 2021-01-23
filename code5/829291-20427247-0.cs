    public static int CharCount(string input,char c)
    {
        var charCount=input.GroupBy(a => a).ToDictionary(k => k.Key, v => v.Count());
        if (charCount.ContainsKey(c))
            return charCount[c];
        return 0;
    }
