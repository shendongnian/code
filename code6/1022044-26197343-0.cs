    void Main()
    {
    	string[] search = { "CAKE", "COFFEE", "TEA", "HONEY", "SUGAR", "CINNEMON" }; 
    	string[] wordsToFind = { "CAKE", "TEAPOT" }; 
    	
    	List<String> wordCollected = search.Where(s => s == wordsToFind[0]).ToList(); 	
    	wordCollected.Dump();
    	wordCollected = search.Where(x => wordsToFind.Any(w => w == x)).ToList();	
    	wordCollected.Dump(); 
    }
