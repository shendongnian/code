         var synth = new SpeechSynthesizer();
         var voice = SpeechSynthesizer.DefaultVoice;
         var newuserText = TheMessage
         var stream = await synth.SynthesizeTextToStreamAsync(newuserText);
         var mediaElement = new MediaElement();
         mediaElement.SetSource(stream, stream.ContentType);
         mediaElement.Play();
