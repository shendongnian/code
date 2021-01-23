    public static int countLetters(string word, char countableLetter)
    {
        int count = 0;
        foreach (char c in word)
        {
            if(countableLetter == c)
               count++;
        }
        return count;
    }
