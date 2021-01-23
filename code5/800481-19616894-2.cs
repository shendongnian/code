    static class Exts
    {
        public static string GetWord(this string source)
        {
            return source.Where(char.IsLetterOrDigit)
                .Aggregate(new StringBuilder(), (acc, x) => acc.Append(x))
                .ToString();
        }
    
        public static string ReplaceWord(this string source, string word, string newWord)
        {
            return String.Join(" ", source
                .Split(new string[] { " " }, StringSplitOptions.None)
                .Select(x =>
                {
                    var w = x.GetWord();
                    return w == word ? x.Replace(w, newWord) : x;
                }));
        }
    }
      
