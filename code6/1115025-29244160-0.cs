        public static string OpposingBases()
        {
            var baseDictionary = new Dictionary<char, char>()
            {
                {'A', 'T'},
                {'T', 'A'},
                {'C', 'G'},
                {'G', 'C'}
            };
            return input1.Where(baseDictionary.ContainsKey).Aggregate("", (current, c) => current + baseDictionary[c]);
        }
