        public static string StripWeirdChars(string source)
        {
            string res = "";
            foreach (char c in source) if ((int)c >= 32) res += c;
            return res;
        }
