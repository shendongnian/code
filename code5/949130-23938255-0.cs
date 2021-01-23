            foreach (string s in list)
            {
                if (HasDoubleCharacter(s))
                {
                    // do something
                }
            }
        private static bool HasDoubleCharacter(string text)
        {
            char[] c3 = text.ToCharArray();
            char lastChar = (char)0;
            foreach (char c in c3)
            {
                if (lastChar == c)
                    return true;
                lastChar = c;
            }
            return false;
        }
