    string[] words = { "testing", "world", "ראשוני", "new", "hello", "test" };
    
    List<string> newText = new List<string>() {			
    	"This line dosent match",
    	"date1",
    	"",
    	"This line does match with the word: hello",
    	"date2",
    	"",
        "This line dosent match either",
    	"date1",
    	"",
    	"This line does match with the word: world",
    	"date4",
    	"",
    };
    
    int i = 0;
    
    while (i < newText.Count)
    {            
        // Get an array of words
        string[] lineWords = newText[i].Split(' ');
    
        if (lineWords.Intersect(words).Count() == 0)
        {
            // This line has no matching words. Remove 3 lines.
            for (int n = 0; n < 3; n++)
                newText.RemoveAt(i);
        }
        else
        {
            // This line has matching words. Move forward 3 lines.
            i += 3;
        }
    }
    
    foreach (string line in newText)
        Console.WriteLine(line);
