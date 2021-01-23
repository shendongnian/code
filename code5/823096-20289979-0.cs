    SpeechRecognitionEngine recognitionEngine recognitionEngine = new SpeechRecognitionEngine();
    recognitionEngine.SetInputToDefaultAudioDevice();
    recognitionEngine.LoadGrammar(new DictationGrammar());
    RecognitionResult result = recognitionEngine.Recognize(new TimeSpan(0, 0, 20));
    foreach (RecognizedWordUnit word in result.Words)
    {
         Console.Write(“{0} “, word.Text);
    }
