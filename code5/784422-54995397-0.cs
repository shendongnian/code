        private static string GetPatternWithoutYear(string pattern)
        {
            if (pattern.EndsWith("yyyy"))
                pattern = pattern.Substring(0, pattern.Length - 5);
            else if (pattern.StartsWith("yyyy"))
                pattern = pattern.Substring(5);
            // some even end with yyyy.
            else if (pattern.EndsWith("yyyy."))
                pattern = pattern.Substring(0, pattern.Length - 5);
            else if (pattern.EndsWith("yy"))
                pattern = pattern.Substring(0, pattern.Length - 3);
            // and some seldom with yy.
            else if (pattern.EndsWith("yy."))
                pattern = pattern.Substring(0, pattern.Length - 3);
            // bul
            else if (pattern.EndsWith("yyyy 'г.'"))
                pattern = pattern.Substring(0, pattern.Length - 9);
            // tuk
            else if (pattern.EndsWith(".yy 'ý.'"))
                pattern = pattern.Substring(0, pattern.Length - 8);
            return pattern;
        }
