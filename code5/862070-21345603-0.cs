    public void SomeOtherFunc()
    {
        List<string> MyTest = new List<string>();
        MyTest.Add( "Mike is not your average guy. I think you are great." );
        MyTest.Add( "Jim is not your friend. I think you are great." );
        MyTest.Add( "Being different is not your fault. I think you are great." );
        string thePhrase = testPhrase( MyTest );
        MessageBox.Show( thePhrase );
    }
    public string testPhrase(List<string> test)
    {
    
        // start with the first string and find the shortest.
        // if we can't find a short string in a long, we'll never find a long string in short
        // Ex "To testing a string that is longer than some other string" 
        // vs "Im testing a string that is short"
        // Work with the shortest string.
        string shortest = test[0];
        string lastGoodPhrase = "";
        string curTest;
        int firstMatch = 0;
        int lastMatch = 0;
        int allFound;
        foreach (string s in test)
            if (s.Length < shortest.Length)
                shortest = s;
    
        // Now, we need to break the shortest string into each "word"
        string[] words = shortest.Split( ' ' );
    
        // Now, start with the first word until it is found in ALL phrases
        for (int i = 0; i < words.Length; i++)
        {
            // to prevent finding "this" vs "is"
            lastGoodPhrase = " " + words[i] + " ";
    
            allFound = 0;
            foreach (string s in test)
            {
                // always force leading space for string
                if ((" "+s).Contains(lastGoodPhrase))
                   allFound++;
                else
                   // if not found in ANY string, its not found in all, get out
                   break;
            }
    
            if (allFound == test.Count)
            {
                // we've identified the first matched field, get out for next phase test
                firstMatch = i;
                // also set the last common word to the same until we can test next...
                lastMatch = i;
                break;
            }
        }
    
        // if no match, get out
        if (firstMatch == 0)
            return "";
    
        // we DO have at least a first match, now keep looking into each subsequent
        // word UNTIL we no longer have a match.
        for( int i = 1; i < words.Length - firstMatch; i++ )
        {
            // From where the first entry was, build out the ENTIRE PHRASE
            // until the end of the original sting of words and keep building 1 word back
            curTest = " ";
            for (int j = firstMatch; j <= firstMatch + i; j++)
                curTest += words[j] + " ";
    
            // see if all this is found in ALL strings
            foreach (string s in test)
                // we know we STARTED with a valid found phrase.
                // as soon as a string NO LONGER MATCHES the new phrase,
                // return the last VALID phrase
                if (!(" " + s).Contains(curTest))
                    return lastGoodPhrase;
    
            // if this is still a good phrase, set IT as the newest
            lastGoodPhrase = curTest;
        }
    
        return lastGoodPhrase;
    }
