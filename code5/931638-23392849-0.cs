    private static int GetDifferences(string firstStr, string secondStr)
    {
        int val = 0;
        char[] first = firstStr.ToCharArray();
        char[] second = secondStr.ToCharArray();
        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] == second[i])
            {
                val++;
            }
        }
        return val;
    }
