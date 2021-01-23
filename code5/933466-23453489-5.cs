        private static string[] GetLetterPairsInAlphabeticalOrder(string s)
        {
            List<string> pairs = new List<string>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (char.ToLower(s[i]) + 1 == char.ToLower(s[i + 1]))
                {
                    pairs.Add(s[i].ToString() + s[i+1].ToString());
                }
            }
            return pairs.ToArray();
        }
