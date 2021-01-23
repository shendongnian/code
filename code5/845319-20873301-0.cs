    static class Program
    {
        static void Main(string[] args)
        {
            var str = "the and also theValue";
            var pattern = @"\b(the|theValue)\b";
            foreach (Match match in Regex.Matches(str, pattern))
            {
                Console.WriteLine(match.Value);
            }
            Console.ReadKey();
        }
    }
