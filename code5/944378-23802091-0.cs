      static void Main(string[] args)
        {
            string test = "word1 word1 word1 word1";
            Console.WriteLine(test);
            // Replace words
            test = ReplaceWords(test, "word1", "test");
            Console.WriteLine(test);
            Console.ReadLine();
        }
        static string ReplaceWords(string input, string word, string replaceWith)
        {
            // Replace first word
            int firstIndex = input.IndexOf(word);
            input = input.Remove(firstIndex, word.Length);
            input = input.Insert(firstIndex, replaceWith);
            // Replace last word
            int lastIndex = input.LastIndexOf(word);
            input = input.Remove(lastIndex, word.Length);
            input = input.Insert(lastIndex, replaceWith);
            return input;
        }
