        static void Main(string[] args)
        {
            var str = new string[] { "foo", "bar", "test" };
            Console.WriteLine(DoValuesMatch(str));
            Console.ReadLine();
        }
        private static bool DoValuesMatch(string[] str)
        {
            return str.Distinct().Count() > 1;
        }
