    static class Exts
    {
        public static string ReplaceWord(this string source, string word, string newWord)
        {
            return String.Join(" ", source
                .Split(new string[] { " " }, StringSplitOptions.None)
                .Select(x => x == word ? newWord : x));
        }
    }
      
