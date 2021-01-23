    public static class Word
    {
        private static bool HasUppercaseLetter(string input, int howMany = 0)
        {
            return input.Count(char.IsUpper) == howMany;
        }
    }
    ...
    const string sampleInput = "heLLo";
    bool hasTwoUppercaseCharacters = Word.HasUppercaseLetter(sampleInput, howMany: 2);
