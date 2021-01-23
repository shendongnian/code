    private void aiutoVocaleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (SpeechSynthesizer synth = new SpeechSynthesizer())
        {        
            synth.SetOutputToDefaultAudioDevice();
    
            synth.Speak(TextBox_stampa_contenuto.Text.Trim());
        }
    } 
