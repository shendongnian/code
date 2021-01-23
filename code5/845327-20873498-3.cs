    public static bool ContainsTheSameSetOfLetters(this string word1, string word2)
    {
        var chars = new HashSet<char>(word1);
        return word2.All(x => chars.Contains(x));
    }
