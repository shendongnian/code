        private static string[] GetLetterPairsInAlphabeticalOrder(string s)
        {
            List<string> pairs = new List<string>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] + 1 == s[i+1])
                {
                    pairs.Add(s[i].ToString() + s[i+1].ToString());
                }
            }
            return pairs.ToArray();
        }
