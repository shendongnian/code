    public static int countLetters(string word, string countableLetters)
    {
        int count = 0;
        foreach (char c in word)
        {
            if(countableLetters.Contains(c))
               count++;
        }
        return count;
    }
