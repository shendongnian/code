    public static string ReplaceSetOfStrings(this string input, Dictionary<string, string> pairsToReplace)
    {
        foreach (var wordToReplace in pairsToReplace)
        {
            input = input.Replace(wordToReplace.Key, wordToReplace.Value);
        }
        return input;
    }
