    static void Main(string[] args)
    {
        List<string> strings = new List<string>() { "12345678", "1", "12", "123456789", "123", "1234", "12345", "123456", "654321" };
        PrintWordss(strings);
        Console.WriteLine(strings.Count + " strings remain.");
    }
    private static bool SatisfiesRulesAndConditions(string word)
    {
        return true;
    }
    private static void PrintWordss(List<string> words)
    {
        var sortedWords = words.OrderByDescending(word => word.Length)
                                   .GroupBy(word => word.Length)
                                   .Select(word => word.First())
                                   .ToList();
        foreach (var word in sortedWords)
        {
            Console.WriteLine(word + " and its lenght is = " + word.Length);
            if (SatisfiesRulesAndConditions(word))
            {
                words.RemoveAll(w => w.Length == word.Length);
            }
        }
    }
