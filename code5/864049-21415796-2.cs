    private Queue<string> utterances;
    private SpeechSynthesizer speech;
    private void TextToSpeech_Play(object sender, EventArgs e)
    {
        speech = new SpeechSynthesizer(CLIENT_ID, CLIENT_SECRET);
        speech.SpeechCompleted += new EventHandler<SpeechEventArgs>(TextToSpeech_Completed); 
    
        foreach (UIElement element in todayschapter.Children)
        {
            if (element is TextBlock)
            {
                string content = (element as TextBlock).Text;
                utterances.Enqueue(content);
            }
        }
        TextToSpeech_Completed(null, null);   // start speaking the first one
    }
    
    private void TextToSpeech_Completed(object sender, SpeechEventArgs e)
    {
         if (utterances.Any())
         {
             string contents = utterances.Dequeue();
             speech.SpeakAsync(contents);
         }
    }
