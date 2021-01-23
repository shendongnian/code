    class Program
    {
        static void Main(string[] args)
        {
            string text = "A AND (B AND C)";
            List<object> result = ParseBlock(text);
            Console.ReadLine();
        }
        private static List<object> ParseBlock(string text)
        {
            List<object> result = new List<object>();
            int bracketsCount = 0;
            int lastIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '(')
                    bracketsCount++;
                else if (c == ')')
                    bracketsCount--;
                if (bracketsCount == 0)
                    if (c == ' ' || i == text.Length - 1)
                    {
                        string substring = text.Substring(lastIndex, i + 1 - lastIndex).Trim();
                        object itm = substring;
                        if (substring[0] == '(')
                            itm = ParseBlock(substring.Substring(1, substring.Length - 2));
                        result.Add(itm);
                        lastIndex = i;
                    }
            }
            return result;
        }
    }
