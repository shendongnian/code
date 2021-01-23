    class Program
    {
        static void Main(string[] args)
        {
            var strings = new string[] { "[1] Bryan Mar", "John Doe [2]", "Mary [3] Cole" };
            var re = new Regex(@"^.*\[(\d)\].*$");
            foreach (var s in strings)
            {
                var m = re.Match(s);
                if (m.Success)
                {
                    Console.WriteLine(m.Groups[1].Value);
                }
            }
            Console.ReadLine();
        }
    }
