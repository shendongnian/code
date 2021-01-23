    private void countWordsInALIne(string line, Dictionary<string, int> words)
    {
        var wordPattern = new Regex(@"\w+");
        foreach (Match match in wordPattern.Matches(line))
        {
            int currentCount=0;
            words.TryGetValue(match.Value, out currentCount);
            currentCount++;
            words[match.Value] = currentCount;
        }
    }
