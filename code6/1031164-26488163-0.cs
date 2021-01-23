    if (voices.Any())
    {
        speech.SetVoice(voices.ElementAt(0));
        await speech.SpeakTextAsync(lblTranslatedText.Text);
    }
