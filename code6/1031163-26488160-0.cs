    IEnumerable<VoiceInformation> voices = from voice in InstalledVoices.All
                                           where voice.Language == filterLanguage
                                           select voice;
    try {
        speech.SetVoice(voices.ElementAt(0));
    } catch (Exception e) {
        // Show a message box or whatever to explain that the voice is not installed.
    }
