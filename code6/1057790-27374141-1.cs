        public static char GetUnknownChar(string s, IEnumerable<char> knownChars)
        {
            var knownSet = new HashSet<char>(knownChars);
            return s.First(knownSet.Contains);
        }
