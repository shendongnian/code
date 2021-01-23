            foreach (string s in list)
            {
                int pos = HasDoubleCharacter(s);
                if (pos > -1)
                {
                    // do something
                }
            }
        private static int HasDoubleCharacter(string text)
        {
            int pos = 0;
            char[] c3 = text.ToCharArray();
            char lastChar = (char)0;
            foreach (char c in c3)
            {
                if (lastChar == c)
                    return pos;
                lastChar = c;
                pos++;
            }
            return -1;
        }
