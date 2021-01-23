        private async void SpeakText(MediaElement audioPlayer, string TTS)
        {
            SpeechSynthesizer ttssynthesizer = new SpeechSynthesizer();
            //Set the Voice/Speaker to Spanish
            using (var speaker = new SpeechSynthesizer())
            {
                speaker.Voice = (SpeechSynthesizer.AllVoices.First(x => x.Gender == VoiceGender.Female && x.Language.Contains("ES")) );
                ttssynthesizer.Voice = speaker.Voice;
            }
            SpeechSynthesisStream ttsStream = await ttssynthesizer.SynthesizeTextToStreamAsync(TTS);
            audioPlayer.SetSource(ttsStream, "");
        }
