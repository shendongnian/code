        static Dictionary<char, string> wordMap = new Dictionary<char, string>();
        static Dictionary<string, char> charMap = new Dictionary<string, char>();
        public static void InitializeLookups()
        {
            wordMap = new Dictionary<char, string>
            {
                { 'A', "Alice" },
                { 'B', "Bob" },
                { 'C', "Charlie" }
            };
            charMap = wordMap.ToDictionary(e => e.Value, e => e.Key);
        }
        public static string ConvertCharToWords(string chars)
        {
            var strings = chars
                  .Select(c =>
                  {
                      string word;
                      if (!wordMap.TryGetValue(c, out word))
                          word = c.ToString();
                      return word;
                  });
            return string.Join(" ", strings);
        }
        public static string ConvertWordsToChars(string words)
        {
            var strings = words.Split(' ')
                  .Select(c =>
                  {
                      char character;
                      if (!charMap.TryGetValue(c, out character))
                          character = '?';
                      return character;
                  });
            return string.Join("", strings);
        }
        public static void Main(string[] args)
        {
            InitializeLookups();
            string words = ConvertCharToWords("ABC");
            string chars = ConvertWordsToChars(words);
            Console.WriteLine(words);
            Console.WriteLine(chars);
        }
