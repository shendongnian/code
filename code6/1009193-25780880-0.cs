    // Declare the SpeechSynthesizer object at the class level.
    SpeechSynthesizer synth;
    
    // Handle the button click event.
    private async void SpeakFrench_Click_1(object sender, RoutedEventArgs e)
    {
      // Initialize the SpeechSynthesizer object.
      synth = new SpeechSynthesizer();
    
      // Query for a voice that speaks French.
      IEnumerable<VoiceInformation> frenchVoices = from voice in InstalledVoices.All
                         where voice.Language == "fr-FR"
                         select voice;
                
      // Set the voice as identified by the query.
      synth.SetVoice(frenchVoices.ElementAt(0));
    
      // Count in French.
      await synth.SpeakTextAsync("un, deux, trois, quatre");
    }
