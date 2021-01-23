    // make sure to set the type of `sr` to SpeechRecognitionEngine
    private void Speak_Load(object sender, EventArgs e)
    {
        sr = new SpeechRecognitionEngine();
        sr.LoadGrammar(new DictationGrammar()); // load a dictation grammar, to allow dictation (recognizing all words)
        sr.SetInputToDefaultAudioDevice();
        sr.SpeechRecognized += sr_SpeechRecognized;
        sr.RecognizeAsync(RecognizeMode.Multiple); // start recognizing
    }
    
    void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        richTextBox1.AppendText(e.Result.Text.ToString() + " ");
    }
