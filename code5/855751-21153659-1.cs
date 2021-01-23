    public static class Word
    {
        public static bool HasUppercaseLetter(string word, int howMany = 0)
        {
            return word.Count(char.IsUpper) == howMany;
        }
    }
