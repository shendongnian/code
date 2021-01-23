    static long CountWordsInstances(string f, string s)
        {
        string text = f;
        string searchTerm = s;
    
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
    
            using (StreamReader r = new StreamReader(f))
            {              
                string line;
    // there is no guarantee for compiler that you entry in while-block here
                while ((line = r.ReadLine()) != null) 
                {
                    var matchQuery = from word in source
                                     where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                                     select word;
                    int wordCount = matchQuery.Count();  
     // there again is no guarantee to enter in if-block
                    if (!matchQuery.Any())
                    {
                     return wordCount;
                    }
    // so compiler don't know what to return here
                }                
    // and here. (also, you can add just here return or throw statement)
            }
        }
