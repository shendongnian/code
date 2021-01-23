        private async void TextToSpeech(string textToReadAloud)
        {
            SpeechSynthesizer ttssynthesizer = new SpeechSynthesizer();
            //Set the Voice & Speaker
            using (var speaker = new SpeechSynthesizer())
            {
                speaker.Voice = (SpeechSynthesizer.AllVoices.First(x => x.Gender == VoiceGender.Female));
                ttssynthesizer.Voice = speaker.Voice;
            }
            SpeechSynthesisStream ttsStream = await ttssynthesizer.SynthesizeTextToStreamAsync(textToReadAloud);
            MediaElement.SetSource(ttsStream, "");  
        }
