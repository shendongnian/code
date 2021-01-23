    public Dictionary<string, int> AnalyzeString(string str)
    {
        Dictionary<string,int> contents = Dictionary<string,int>();
        string[] words = str.Split(' ');
        foreach(string word in words)
        {
            if(contents.ContainsKey(word))
            {
                contents[word]+=1;
            }
            else
            {
                contents.Add(word,1);
            }
        }
        return contents;
    }
