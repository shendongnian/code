    internal class Program
    {
        private Action Empty { get; set; }
        private static void Main(string[] args)
        {
            string lines = File.ReadAllText(path: @"readme.txt");
            string[] words = SplitWords(lines);
            foreach (var  word in words)
            {
                Console.WriteLine(word);
            }
        }
        private static string[] SplitWords(string s)
        {
            return Regex.Split(s, @"\W+");
        }
    }
