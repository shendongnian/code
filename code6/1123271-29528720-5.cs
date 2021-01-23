    class Program
    {
        public static void Main(params string[] args)
        {
            var seps = new[] { "\n" };
            var string0 = "00000010\n001000\n000100\n000100";
            var string1 = "001000\n000100\n000100";
            var string4 = "10001000\n00100100\n00000100";
            var string2 = "10\n01\n01";
            var string3 = "010\n010\n010";
            Console.WriteLine(string1.CountMatches(string2, seps));
            Console.WriteLine(string1.CountMatches(string3, seps));
            Console.WriteLine(string4.CountMatches(string2, seps));
            Console.WriteLine(string4.CountMatches(string3, seps));
            Console.WriteLine(string0.CountMatches(string2, seps));
        }
    }
