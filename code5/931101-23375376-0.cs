    private async void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
    {
        // The media object for controlling and playing audio.
        MediaElement mediaElement = this.media;
        // The object for controlling the speech synthesis engine (voice).
        var synth = new SpeechSynthesizer();
        // Generate the audio stream from plain text.
        SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello World");
        // Send the stream to the media object.
        mediaElement.SetSource(stream, stream.ContentType);
        mediaElement.Play();
    }
