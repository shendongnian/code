    class Program
    {
        static void Main(string[] args)
        {
    
            string[] words = new string[] { "WordOne", "WordTwo", "WordThree", "WordFour" };
            string[] clues = new string[] { "ClueOne", "ClueTwo", "ClueThree", "ClueFour" };
    
            foreach (string word in words)
            {
                Console.WriteLine("Current word is " + word);
            }
    
            Console.WriteLine();
    
            foreach (string clue in clues)
            {
                Console.WriteLine("Current clue is " + clue);
            }
    
            Console.WriteLine();
    
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < clues.Length; j++)
                {
                    words[i] = words[i].Replace(words[i], clues[j]);
                }
            }
    
            foreach (string newWord in words)
            {
                Console.WriteLine("New Word is now " + newWord);
            }
    
            Console.Read();
        }
    }
