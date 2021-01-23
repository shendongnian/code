        public static bool Balanced(string s)
        {
            var ix = -1;
            return Balanced(s, false, ref ix);
        }
        private static bool Balanced(string s, bool inParens, ref int ix)
        {
            ix++;
            while (ix < s.Length)
            {
                switch (s[ix++])
                {
                    case '(':
                        if (!Balanced(s, true, ref ix))
                            return false;
                        break;
                    case ')':
                        return inParens;
                }
            }
            return !inParens;
        }
