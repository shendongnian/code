    private static void PrintWordss(List<string> words)
    {
        var sortedWords = words.OrderByDescending(word => word.Length)
                                   .GroupBy(word => word.Length)
                                   .Select(word => word.First())
                                   .ToList();
        // Clone list so original isn't modified.
        var copyofWords = words.Select(item => (string)item.Clone()).ToList();
        foreach (var word in sortedWords)
        {
            Console.WriteLine(word + " and its lenght is = " + word.Length);
            if (SatisfiesRulesAndConditions(word))
            {
                copyofWords.RemoveAll(w => w.Length == word.Length);
            }
        }
    }
