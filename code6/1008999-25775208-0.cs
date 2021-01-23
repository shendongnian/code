    public string CheckSpelling(string theString)
    {
        //loop to check all words
        foreach(string word in correctWords
        {
            if (theString.Equals(word))
            {
                return "Word " + theString + " is spelled correctly." +     Assembly.GetExecutingAssembly().GetName().Name + Assembly.GetEntryAssembly().GetName().Version ;
            }
        }
        return "Invalid Spelling";
    }
