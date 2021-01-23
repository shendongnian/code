    private async Task SpeakAsync(string text)
    {
      MediaElement mediaElement = this.media;
      var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
      SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);
      mediaElement.SetSource(stream, stream.ContentType);
      await mediaElement.PlayToEndAsync();
    }
