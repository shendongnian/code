        private void initSpeech()
        {
                // You need to change here if you are not using kinect camera 
                RecognizerInfo ri = SpeechRecognitionEngine.InstalledRecognizers().Where(r => r.Id == "SR_MS_en-US_Kinect_10.0").FirstOrDefault();
                if (ri == null)
                {
                        throw new ApplicationException("Could not locate speech recognizer. Ensure you have the Kinect Speech SDK/runtime/MSKinectLangPack_enUS installed.");
                }
    
                sr = new SpeechRecognitionEngine(ri.Id);
                //Phrases that will be recognised added
                Choices phrases = new Choices();
                phrases.Add(
                    "faster", 
                    "slower", 
                    "stop", 
                    "invert y",
                    "music volume",
                    "effects volume",
                    "okay");
                GrammarBuilder gb = new GrammarBuilder();
                //adding our phrases to the grammar builder
                gb.Append(phrases);
                // Loading the grammer 
                sr.LoadGrammar(new Grammar(gb));
        }
