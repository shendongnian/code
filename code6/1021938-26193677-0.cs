    private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      if (e.Result.Text == "Exit")
      {
               Choices sList = new Choices();
              sList.Add(new String[] { "Yes"});
              Grammar gr = new Grammar(new GrammarBuilder(sList));
              sRecognize.RequestRecognizerUpdate();
              sRecognize.LoadGrammar(gr);
              sRecognize.SpeechRecognized += delegate(object sender,     SpeechRecognizedEventArgs e)   
                      {   
                           Application.Exit();
                      };
              sRecognize.SetInputToDefaultAudioDevice();
              sRecognize.RecognizeAsync(RecognizeMode.Multiple);
      }
  }
