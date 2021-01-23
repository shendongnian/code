    public static string RemoveBadChars(string word)
    {
        char[] chars = new char[word.Length];
        int myindex=0;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
    
            if ((int)c >= 65 && (int)c <= 90)
            {
                chars[myindex] = c;
                myindex++;
            }
            else if ((int)c >= 97 && (int)c <= 122)
            {
                chars[myindex] = c;
                myindex++;
            }
            else if ((int)c == 44)
            {
                chars[myindex] = c;
                myindex++;
            }
        }
    
        word = new string(chars);
    
        return word;
    }
