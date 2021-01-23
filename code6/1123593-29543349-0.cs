    public int CountVowels(List<string> words)
    {
        return words.Sum(CountVowels);
    }
    public int CountVowels(string word)
    {
        return Enumerable.Range(0, word.Length).Count(i => IsVowel(word, i));
    }
    public bool IsVowel(string word, int i)
    {
        if (i < 0) return false;
        if (i >= word.length) return false;
        switch(word[i].ToLowerCase())
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
            case 'y':
                // I'm pretty sure 'y' is a consonant if it follows, 
                // or is followed by a vowel
                return !(IsVowel(word, i-1) || IsVowel(word, i+1));
        }
        return false;
    }
