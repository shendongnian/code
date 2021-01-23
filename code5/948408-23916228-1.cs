    string[] quotesplit = stringamabob.Split('"'); //Split by quotes.
    char[] delimitedChars = { ',', '\n'}; //remove quotes from these delimiters because we've already split by them
    List<string> words = new List<string>();
    bool toggle = stringamabob.StartsWith("\""); //check if the first item is quoted
    foreach(string chunk in quotesplit)
    {
        if(toggle) //toggle is true when we're not inside quotes
        {
            words.AddRange(chunk.Split(delimitedChars));
        }
        else
        {
            words.Add(chunk);
        }
        toggle = !toggle;
    }
