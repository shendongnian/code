    static string WordMap(string data)
    {
        const string words = "Alpha Beta Gamma Delta ...";
        string[] wordMap = words.Split(' ');
        var output = new StringBuilder();
        foreach (char c in data)
        {
            int index = c - 'a';
            if (index >= 0 && index < wordMap.Length)
            {
                output.Append(wordMap[index]);
                output.Append(' ');
            }
        }
        return output.ToString();
    }
