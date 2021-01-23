    List<string> words = new List<string> {...};
    Dictionary<string, int> counts = new Dictionary<string, int>();
    
    foreach (string word in words)
    {
        if (counts.ContainsKey(word))
        { 
            counts[word] += 1;
        }
        else
        {
            counts[word] = 1;
        }
    }
