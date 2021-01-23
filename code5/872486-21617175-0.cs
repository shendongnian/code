    bool helloFlag = false;
    void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        //First time you say something
        if (e.Result.Text == "hello")
        {
            Scot.Speak("Hello sir");
            helloFlag = true;
        }
        
        //Second time you say something
        if ( ( helloFlag == true ) && (e.Result.Text == "how are you") )
        {
            Scot.Speak("im good sir");
        }
    }
