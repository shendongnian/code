        static void Main(string[] args)
        {
            const string startingString = "one two three four";
            List<string> l = startingString.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var combinations = l.Select(q => FindPairs(q, l))
                       .ToList()
                       .SelectMany(r => r);
            foreach (var combination in combinations)
            {
                Console.WriteLine(String.Join(",", combination));
            }
        }
        private static List<List<string>> FindPairs(string s, List<string> list)
        {
            List<List<string> > result = new List<List<string>>();
            int index = list.IndexOf(s);
            for (int t = 2; t < list.Count; t++)
            {
                if (index + t <= list.Count)
                {
                    var words = list.Skip(index).Take(t).ToList();
                    if (words.Count() >= 2)
                    {
                        result.Add(words);
                    }
                }
            }
            return result;
        }
