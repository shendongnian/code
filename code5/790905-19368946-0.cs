    class Program
    {
        static void Main(string[] args)
        {
            string sentence = string.Empty;
            sentence = Console.ReadLine();
            
            var sent = sentence
                .Split(' ')
                .Distinct()
                .OrderBy(x => x);
            foreach (string s in sent)
            {
                Console.WriteLine(s.ToLower());
            }
            Console.ReadLine();
        }
    }
