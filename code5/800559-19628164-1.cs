    void Engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        txtSpeech.Text = e.Result.Text;
        ExtractKeywords(e.Result.Text);
    
        if (e.Result.Grammar.Name.Equals("Google Search"))
        {
             OpenApp("www.google.com", result);
        }
        else if (e.Result.Grammar.Name.Equals("StackOverflow Search"))
        {
             OpenApp("www.stackoverflow.com", result);
        }
        // etc...
    }
