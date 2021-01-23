    default:
        if (speech.ToLower().Contains("search for")) // See if the string contains the 'search for' string.
        {
             var dictationGrammar= new DictationGrammar();
                sre.LoadGrammarAsync(dictationGrammar);
    string url = "https://www.google.com.au/search?q=" + dictationGrammar;
         System.Diagnostics.Process.Start(url);
        }
        break;
   
