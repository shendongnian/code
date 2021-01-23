    private SpeechSynthesizer synth = new SpeechSynthesizer();
    
    private async void Button_Click(object sender, RoutedEventArgs e) 
    {
        await synth.SpeakTextAsync("You have an incoming notification from Big Bank.");
    }
       
    private void Button_Click_1(object sender, RoutedEventArgs e) 
    {
           synth.CancelAll();
    }
