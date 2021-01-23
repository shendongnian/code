    public static unsafe int CountWords(string s)
    {
        int count = 0;
        fixed (char* ps = s)
        {
            int len = s.Length;
            bool inWord = false;
            char* pc = ps;
            while (len-- > 0)
            {
                if (char.IsWhiteSpace(*pc++))
                {
                    if (!inWord)
                    {
                        inWord = true;
                    }
                }
                else
                {
                    if (inWord)
                    {
                        inWord = false;
                        count++;
                    }
                }
                if (len == 0)
                {
                    if (inWord)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
