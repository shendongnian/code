    class Program
        {
            static void Main(string[] args)
            {
                string input = "one, two, three, four, five and six";
    
                // Get all nouns into a string array
                string [] allNouns = getNouns(input);
    
                // Print the result
                foreach (string noun in allNouns)
                {
                    Console.WriteLine(noun);                
                }
                Console.ReadLine();
            }
    
            private static string[] getNouns(string input)
            {
                string[] nouns = input.Split(',');
    
                if (input.ToLower().IndexOf("and") > 0 && nouns.Length > 0)
                {
                    string[] lastTwoNouns = nouns[nouns.Length - 1].Trim().ToLower().Replace(" and", "").Split(' ');
    
                    Array.Resize(ref nouns, nouns.Length + 1);
    
                    nouns[nouns.Length - 2] = lastTwoNouns[0];
                    nouns[nouns.Length - 1] = lastTwoNouns[1];
                }
    
                for (int i = 0; i < nouns.Length; i++)
                {
                    nouns[i] = nouns[i].Trim();
                }
    
                return nouns;
            }
        }
