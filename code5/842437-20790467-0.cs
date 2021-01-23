    static long CountWordsInstances(string f, string s)
    {
    string text = f;
    string searchTerm = s;
    string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
    using (StreamReader r = new StreamReader(f))
    {              
        string line;
        while ((line = r.ReadLine()) != null)
        {
            var matchQuery = from word in source
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;
            int wordCount = matchQuery.Count();  
            if (!matchQuery.Any())
            {
                 return wordCount;
            }
          }
       // Answer Mod Here!
       return 0; 
       // Or whatever value you think should be returned if your condition
       // is not met above.    
    }
