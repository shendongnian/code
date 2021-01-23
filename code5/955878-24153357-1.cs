    class Program
    {
        static void Main(string[] args)
        {
            var validWords = new List<string>(File.ReadAllText("AllWords.txt").Split(' '));
            foreach (var result in validWords.Where(word => 
                         IsWordInString(word, "ABCDEFGHIJKLMNOP")))
            {
                Console.WriteLine(result);   
            }
        }
        static bool IsWordInString(string word, string source)
        {
            var letterList = source.ToList();
            return word.All(letterList.Remove);
        }
    }
