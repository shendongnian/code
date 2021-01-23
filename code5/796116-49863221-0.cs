    public static List<Tuple<string, string>> RegexSplitDetail(this string text, string pattern)
    {
        var splitAreas = new List<Tuple<string, string>>();
            
        var regexResult = Regex.Matches(text, pattern);
        var regexSplit = Regex.Split(text, pattern);
        for (var i = 0; i < regexSplit.Length; i++)
            splitAreas.Add(new Tuple<string, string>(i == 0 ? null : regexResult[i - 1].Value, regexSplit[i]));
            
        return splitAreas;
    }
    ...
    var result = exampleSentence.RegexSplitDetail(@"\d+");
