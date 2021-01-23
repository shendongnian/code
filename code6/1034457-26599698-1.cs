    Dictionary<string, int> concordanceDictionary = new Dictionary<string, int>();
    string myText = File.ReadAllText("C:\Text.txt").ToLower();
    string[] words = SplitWords(myText);
    foreach (var word in words)
    {
        int i = 1;
        if (!concordanceDictionary.ContainsKey(word))
        {
            WordInfo word = new WordInfo(word, i);
            concordanceDictionary.Add(word, i);
        }
        else
        {
            concordanceDictionary[word].WordCount++;
            concordanceDictionary[word].LineNumbers.Add(i);
        }
        i++;
    }
