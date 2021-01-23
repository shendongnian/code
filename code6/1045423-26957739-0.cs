      SpeechSynthesizer synth = new SpeechSynthesizer();
      synth.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);
      //
      string s1 = "I love Stack Overflow";
      PromptBuilder builder = new PromptBuilder();
      builder.AppendSsmlMarkup("I love <emphasis>Stack Overflow</emphasis>");
      builder.AppendText(s1);
      builder.AppendText(s1, PromptEmphasis.Strong);
      builder.AppendText(s1, PromptRate.ExtraFast);
      builder.AppendText(s1,PromptVolume.Loud);
      //
      synth.Speak(builder);    
    static void synth_SpeakProgress (object sender, SpeakProgressEventArgs e)
    {
      Console.WriteLine("Speak progress: {0} AudioPosition: {1} Text: {2}", e.CharacterPosition, e.AudioPosition, e.Text);
    }
    
