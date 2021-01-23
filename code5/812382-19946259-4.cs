    /// <summary>
    /// Removes words from a string that are greater or less than the supplied lengths
    /// </summary>
    /// <param name="inputString">the input string to parse</param>
    /// <param name="preservePuncuation">flag to preserve the puncation for rebuilding the string</param>
    /// <param name="minWordLength">the minimum word length</param>
    /// <param name="maxWordLength">the maximum word length</param>
    /// <returns></returns>
    public static string RemoveWords(string inputString, bool preservePuncuation, int minWordLength, int maxWordLength)
    {
        //parse our string into pieces for iteration
        var words = WordProcessor.ParseString(inputString, preservePuncuation);
    
        //initialize our complete string container
        List<string> completeString = new List<string>();
    
        //enumerate each word
        foreach (var word in words)
        {
            //does the word index of zero matches our word split (as puncuation is one character)
            if (wordSplitPuncuation.IndexOf(word[0]) > -1)
            {
                //are we preserviing puncuation
                if (preservePuncuation)
                    //add the puncuation
                    completeString.Add(word);
            }
            //check that the word length is greater or equal to the min length and less than or equal to the max word length
            else if (word.Length >= minWordLength && word.Length <= maxWordLength)
                //add to the complete string list
                completeString.Add(word);
        }
        //return the completed string by joining the completed string contain together, removing all double spaces and triming the leading and ending white spaces
        return string.Join("", completeString).Replace("  ", " ").Trim();
    }
