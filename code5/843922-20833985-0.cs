    public static class Extensions
    {
        private static Random rand = new Random(1);
        public static string Random(this string str)
        {
            var chars = new List<string>();
            var strElements = StringInfo.GetTextElementEnumerator(str);
            while (strElements.MoveNext())
            {
                chars.Add(strElements.GetTextElement());
            }
            return chars[rand.Next(chars.Count)];
        }
    }
