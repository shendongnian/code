    public static class Taxiway
    {
        private static Dictionary<char, string> lookup = new string[]
        {
            "ALPHA",
            "BRAVO",
            "CHARLIE",
            ...
            "ZULU",
            "1",
            "2",
            ...
            "9"
        }.ToDictionary(s => s[0]);
    
        public static string Parse(string s)
        {
            if (s == null || s.Length < 1 || s.Length > 2
                || !s.All(c => lookup.ContainsKey(c))
                || !char.IsLetter(s[0]))
            {
                throw new ArgumentException("Invalid taxiway.", "s");
            }
            return string.Join(" ", s.Select(c => lookup[c]));
        }
    }
