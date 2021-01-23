        public int CommonCharacters(char[] s1, char[] s2)
        {
            bool[] matchedFlag = new bool[s2.Count()];
            for (int i1 = 0; i1 < s1.Count(); i1++)
            {
                for (int i2 = 0; i2 < s2.Count(); i2++)
                {
                    if (s1[i1] == s2[i2] && !matchedFlag[i2])
                    {
                        matchedFlag[i2] = true;
                        break;
                    }
                }
            }
            return matchedFlag.Count(u => u);
        }
