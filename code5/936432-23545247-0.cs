    public static string RemoveDuplicates(string input, params string[] wordsToCheck)
    {
        var wordSet = new HashSet<string>(wordsToCheck);
        int taken = 0;
        var newWords = input.Split()
            .Select(w => !wordSet.Contains(w) || ++taken == 1 ? w : "");
        return string.Join(" ", newWords);
    }
