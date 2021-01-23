    var waveStream = new MemoryStream();
    using (var synthesizer = new SpeechSynthesizer())
    {
        var synthFormat =  
            new SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Stereo);
        string text = "Hello World! Speech";
        // Or SetOutputToWaveStream...
        synthesizer.SetOutputToAudioStream(waveStream, synthFormat);
        synthesizer.Speak("Hello World! Speech");
    }
    using (var file = File.Create(path))
    {
        // With WriteTo, you don't need to rewind first...
        waveStream.WriteTo(file);
    }
