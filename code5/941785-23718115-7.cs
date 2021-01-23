    foreach (var group in sortedWords.GroupBy(x => x.Length))
    {
        foreach(var word in group)
        {        
            if(SatisfiesRulesAndConditions(word))
            {
                Console.WriteLine(word  + " and its length is = " + word.Length);
                break;
            }
        }
    }
