    public static class Extensions
    {
        public static IEnumerable<string> GetWords(this string source,int firstWordLengt,int secondWordLenght)
        {
            List<string> words = new List<string>();
            foreach (var word in source.Split(new[] {'`'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = word.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                words.Add(new string(parts[0].Take(firstWordLengt).ToArray()));
                words.Add(new string(string.Join(" ",parts.Skip(1)).Take(secondWordLenght).ToArray()));
            }
            return words;
        }
    }
