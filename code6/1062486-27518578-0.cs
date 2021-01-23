        static void Main(string[] args)
        {
            Random r = new Random();
            string letters = "abcdefghijklmnopqrstuvwxyz";
            List<string> dictionary = new List<string>(new string[] { 
                "compartmentalization", "inheritance", "polymorphism", 
                "paradigm", "abstraction", "aggregration", "cryptography",
                "pseudocode", "recursion", "backtracking", "alogrithm"
            });
            string word = dictionary[r.Next(dictionary.Count)];
            List<int> indexes = new List<int>();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < word.Length; i++)
            {
                sb.Append(letters[r.Next(letters.Length)]);
                if (sb[i] != word[i])
                {
                    indexes.Add(i);
                }
            }
            Console.WriteLine(sb.ToString());
            while(indexes.Count > 0)
            {
                int index;
                for(int i = indexes.Count - 1; i >= 0; i--)
                {
                    index = indexes[i];
                    sb[index] = letters[r.Next(letters.Length)];
                    if (sb[index] == word[index])
                    {
                        indexes.RemoveAt(i);
                    }
                }
                Console.WriteLine(sb.ToString());
            }
            Console.ReadLine();
        }
