    Dictionary<string, WordInfo> concordanceDictionary = new Dictionary<string, WordInfo>();
    int i = 1;
    foreach (var line in File.ReadLines(@"C:\Text.txt"))
    {
        foreach (string word in SplitWords(line).ToLower())
        {
            if (!concordanceDictionary.ContainsKey(word))
            {
                concordanceDictionary.Add(word, new WordInfo(word, i));
            }
            else
            {
                concordanceDictionary[word].WordCount++;
                if (!concordanceDictionary[word].LineNumbers.Contains(i))
                {
                    concordanceDictionary[word].LineNumbers.Add(i);
                }
            }
        }
        i++;
    }
