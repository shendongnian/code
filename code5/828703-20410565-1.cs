    public string AstrixSomeWords(string test)
    {
        Regex regex = new Regex(@"\b\w+\b");
        return regex.Replace(test, AsterixWord);
    }
    private string AsterixWord(Match match)
    {
        string word = match.Groups[0].Value;
        if (myWords.Contains(word))
            return new String('*', word.Length);   
        else
            return word;
    }
