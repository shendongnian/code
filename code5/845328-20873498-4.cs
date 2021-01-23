    public static bool ContainsTheSameSetOfLetters(string word1, string word2)
    {
        var chars = word1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        return word2.GroupBy(x => x).All(g => chars.ContainsKey(g.Key) && chars[g.Key] >= g.Count());
    }
