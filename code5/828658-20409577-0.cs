    class Program
    {
        static void Main(string[] args)
        {
            string s = "a,,,b,c,,,,d";
            Console.WriteLine(string.Join(",",
                s.Split(',')
                .Select(c => string.IsNullOrEmpty(c) ? "null" : c)));
        }
    }
