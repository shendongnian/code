    //WordCount methos will count the spaces and punciation.
    private int WordCount(string str)
    {
        int words = 0; //the number of words counted
        //count the white spaces and punctuation.
        foreach (char ch in str)
        {
            if (char.IsWhiteSpace(ch))
            {
                words++;
            }
            if (char.IsPunctuation(ch))
            {
                words++;
            }
       }
       //return number of words
       return words;
    }
