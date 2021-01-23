        private static char[] romanLetters = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        private static string[] vals = { "IIIII", "VV", "XXXXX", "LL", "CCCCC", "DD" };
        static string RomanSubtract(string a, string b)
        {
            var _a = new StringBuilder(a);
            var _b = new StringBuilder(b);
            var aIndex = a.Length - 1;
            var bIndex = b.Length - 1;
            while (_a.Length > 0 && _b.Length > 0)
            {
                if (characters match)
                {
                    if (lookahead for a finds a smaller char)
                    {
                        aIndex = ReplaceRomans(_a, aIndex, aChar);
                        continue;
                    }
                    if (lookahead for b finds a smaller char)
                    {
                        bIndex = ReplaceRomans(_b, bIndex, bChar);
                        continue;
                    }
                    _a.Remove(aIndex, 1);
                    _b.Remove(bIndex, 1);
                    aIndex--;
                    bIndex--;
                }
                else if (aChar > bChar)
                {
                    aIndex = ReplaceRomans(_a, aIndex, aChar);
                }
                else
                {
                    bIndex = ReplaceRomans(_b, bIndex, bChar);
                }
            }
            return _a.Length > 0 ? _a.ToString() : "-" + _b.ToString();
        }
        private static int ReplaceRomans(StringBuilder roman, int index, int charIndex)
        {
            if (index > 0)
            {
                var beforeChar = Array.IndexOf(romanLetters, roman[index - 1]);
                if (beforeChar < charIndex)
                {
                    Replace e.g. IX with VIIII
                }
            }
            Replace e.g. V with IIIII
        }
