    // Handle the SpeechRecognized event.
    static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      if (actionRunning) {
          speak("Busy");
      }
      if (e.Result.Text.Equals("what is the time")) {
          actionRunning = true;
          startAction() 
      }
      Console.WriteLine("Speech recognized: " + e.Result.Text);
    }
