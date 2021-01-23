        static void Main(string[] args)
        {
            Console.WriteLine(sPart("zts3e	Großer Fuchs"));
            Console.ReadKey();
        }
        public static string sPart(string original)
        {
            string[] values = original.Split('\t');
            List<string> words = values.Skip(1).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var word in words)
            {
                sb.Append(word + " ");
            }
            return sb.ToString();
        }
