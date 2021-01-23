    class Program
    {
        static void Main(string[] args)
        {
            string str = "goeirjew98rut34ktljre9t30t4j3der";
            var parts = str.SplitInParts(8);
            foreach (var part in parts)
            {
                string formattedString = part.MultiInsert("_", 2, 6);
                Console.WriteLine(formattedString);
            }
            Console.ReadKey();
        }
    }
    static class StringExtensions
    {
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");
            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
        public static string MultiInsert(this string str, string insertChar, params int[] positions)
        {
            StringBuilder sb = new StringBuilder(str.Length + (positions.Length * insertChar.Length));
            var posLookup = new HashSet<int>(positions);
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(str[i]);
                if (posLookup.Contains(i))
                    sb.Append(insertChar);
            }
            return sb.ToString();
        }
    }
