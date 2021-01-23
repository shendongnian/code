    /// <summary>
    /// Removes words from a file
    /// </summary>
    /// <param name="filePath">the file path to parse</param>
    /// <param name="preservePuncuation">flag to preserve the puncation for rebuilding the string</param>
    /// <param name="minWordLength">the minimum word length</param>
    /// <param name="maxWordLength">the maximum word length</param>
    public static void RemoveWordsFromAFile(string filePath, bool preservePuncuation, int minWordLength, int maxWordLength)
    {
                
    
        //our parsed string
        string parseString = "";
    
        //read the file
        using (var reader = new StreamReader(filePath))
        {
            parseString = reader.ReadToEnd();
        }
    
        //open a new writer
        using (var writer = new StreamWriter(filePath))
        {
            //parse our string to remove words
            parseString = WordProcessor.RemoveWords(parseString, preservePuncuation, minWordLength, maxWordLength);
    
            //write our string
            writer.Write(parseString);
            writer.Flush();
        }
    }
