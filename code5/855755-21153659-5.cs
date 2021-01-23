    public static class Word
    {
        public static bool HasUppercaseLetter(string word, int howManyUpper = 1)
        {
            return word.Count(char.IsUpper) == howManyUpper;
        }
        public static int HowManyWordsHaveUppercaseLetters(string sentence, 
            int howManyUpper = 1)
        {
            var words = sentence.Split(new[] {' '});
            return words.Count(w => HasUppercaseLetter(w, howManyUpper));
        } 
    }
