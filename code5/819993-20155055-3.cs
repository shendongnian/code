    public string BoldBeforeString(string source, string bolded, 
                                   int boldBeforePosition)
    {   
        string beforeSelected = source.Substring(0, boldBeforePosition).TrimEnd();
    
        int testedWordStartIndex = beforeSelected.LastIndexOf(' ') + 1;
    
        string boldedString;
        if (beforeSelected.Substring(testedWordStartIndex).Equals(bolded))
        {
            boldedString = source.Substring(0, testedWordStartIndex) + 
                           "<strong>" + bolded + "</strong>" + 
                           source.Substring(testedWordStartIndex + bolded.Length);
        }
        else 
        {
            boldedString = source;
        }
        return boldedString;
    }
    string phrase = "I’m a member of the Imperial Senate on a diplomatic mission to Alderaan.";
    string boldedPhrase = BoldBeforeString(phrase, "a", 41);
