    private void startRecognition()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(); //default culture
            //SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new CultureInfo("de-DE"));
            //With specified culture | Could cause an CultureNotFoundException
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                if(result != null)
                    result_textBox.Text += result.Text + "\r\n"; 
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message,exception.Source);
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }                
        }
