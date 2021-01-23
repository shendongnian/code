    public void GenerateWord()
    {
        Random rn = new Random();
        string[] attemptedWords = LoadUsedWords();
        string[] wordArr = { "PROGRAMMERING", "CSHARP", "STOL", "ELEV", "VISUAL", "STUDIO" };
        string word = wordArr.Except(attemptedWords).OrderBy(x => rn.Next()).FirstOrDefault();
        if (string.IsNullOrEmpty(word))
        {
            Console.WriteLine("Oh no");
        }
        else
        {
            Console.WriteLine(word);
        }
    }
    public string[] LoadUsedWords()
    {
        return new string[] { "PROGRAMMERING", "CSHARP", "STOL", "ELEV", "VISUAL" };
    }
