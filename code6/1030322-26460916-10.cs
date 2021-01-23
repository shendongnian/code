    public static string RemoveChars(string text, string charsToRemove)
    {
        char[] result = new char[text.Length];
        char[] targets = charsToRemove.ToCharArray();
        int n = 0;
        int m = targets.Length;
        foreach (char ch in text)
        {
            if (m == 0)
            {
                result[n++] = ch;
            }
            else
            {
                int index = findFirst(targets, ch, m);
                if (index < 0)
                {
                    result[n++] = ch;
                }
                else
                {
                    if (m > 1)
                    {
                        --m;
                        targets[index] = targets[m];
                    }
                    else
                    {
                        m = 0;
                    }
                }
            }
        }
        return new string(result, 0, n);
    }
    private static int findFirst(char[] chars, char target, int n)
    {
        for (int i = 0; i < n; ++i)
            if (chars[i] == target)
                return i;
        return -1;
    }
