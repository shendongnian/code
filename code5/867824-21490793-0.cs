    public class Program
    {
        static Dictionary<char, string> wordMap = new Dictionary<char, string>();
        static Dictionary<string, char> charMap = new Dictionary<string, char>();
        public static void InitializeLookups()
        {
            charMap = new Dictionary<string, char>
            {
                {"alpha", 'a'},{"beta",'Y'},{"gamma", 'g'},{"delta", '='}
            };
            wordMap = charMap.ToDictionary(e => e.Value, e => e.Key);
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
                          character = 'X';
                      return character;
                  });
            return string.Join("", strings);
        }
        public static void Main(string[] args)
        {
            InitializeLookups();
            string chars = ConvertWordsToChars("alpha beta gamma delta");
            Console.WriteLine(chars);
        }
    }
