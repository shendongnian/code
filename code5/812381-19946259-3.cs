    /// <summary>
    /// characters that denote a new word
    /// </summary>
    const string wordSplitPuncuation = ",.!&()[] \"";
    
    /// <summary>
    /// Parse a string
    /// </summary>
    /// <param name="inputString">the string to parse</param>
    /// <param name="preservePuncuation">preserve punctuation in the string</param>
    /// <returns></returns>
    public static IList<string> ParseString(string inputString, bool preservePuncuation)
    {
        //create a list to hold our words
        List<string> rebuildWords = new List<string>();
    
        //the current word
        string currentWord = "";
    
        //iterate through all characters in a word
        foreach(var character in inputString)
        {
            //is the character is part of the split characters 
            if(wordSplitPuncuation.IndexOf(character) > -1)
            {
                if (currentWord != "")
                    rebuildWords.Add(currentWord);
                if (preservePuncuation)
                    rebuildWords.Add("" + character);
                currentWord = "";
            }
            //else add the word to the current word
            else
                currentWord += character;
        }
        return rebuildWords;
    }
