    class Program
    {
        static void Main(string[] args)
        {
            List<string> validStrings = new List<string>
            {
                "best 5 products",
                "5 best products",
                "products 5 best",
                "best anything 5 products",
                "5 anything best products",
                "products 5 anything best",
            };
            List<string> invalidStrings = new List<string>
            {
                "best 5 products.",
                "5 best product;s",
                "produc.ts 5 best",
                "best anything 5 product/s",
                "5 anything best produc-ts",
                "products 5 anything be_st",
            };
            string pattern1 = @"^(([A-Za-z0-9\s]+\s+)|\s*)[0-9]\s+([A-Za-z0-9\s]+\s+)?best((\s+[A-Za-z0-9\s]+)|\s*)$";
            string pattern2 = @"^(([A-Za-z0-9\s]+\s+)|\s*)best\s+([A-Za-z0-9\s]+\s+)?[0-9]((\s+[A-Za-z0-9\s]+)|\s*)$";
            string pattern = string.Format("{0}|{1}", pattern1, pattern2);
            foreach (var str in validStrings)
            {
                bool match = Regex.IsMatch(str, pattern);
                Console.WriteLine(match);
            }
            Console.WriteLine();
            foreach (var str in invalidStrings)
            {
                bool match = Regex.IsMatch(str, pattern);
                Console.WriteLine(match);
            }
            Console.Read();
        }
    }
