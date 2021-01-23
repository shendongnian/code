    public partial class TestPage : PhoneApplicationPage  
        {  
            SpeechRecognizerUI speechRecognizer;  
      
            // Constructor  
            public TestPage ()  
            {  
                InitializeComponent();  
      
                this.speechRecognizer = new SpeechRecognizerUI();  
            }  
      
            private async void STT_Freeform(object sender, RoutedEventArgs e)  
            {  
                this.speechRecognizer.Recognizer.Grammars.Clear();  
      
                // Use the short message dictation grammar with the speech recognizer.  
                this.speechRecognizer.Recognizer.Grammars.AddGrammarFromPredefinedType("message", SpeechPredefinedGrammar.Dictation);  
      
                await this.speechRecognizer.Recognizer.PreloadGrammarsAsync();  
      
                try  
                {  
                    // Use the built-in UI to prompt the user and get the result.  
                    SpeechRecognitionUIResult recognitionResult = await this.speechRecognizer.RecognizeWithUIAsync();  
      
                    if (recognitionResult.ResultStatus == SpeechRecognitionUIStatus.Succeeded)  
                    {  
                        // Output the speech recognition result.  
                        txtDictationResult.Text = "You said: " + recognitionResult.RecognitionResult.Text;  
                    }  
                }  
                catch (Exception ex)  
                {  
                    MessageBox.Show(ex.Message);  
                }  
            }  
      
            private async void btnWebSearch_Click(object sender, RoutedEventArgs e)  
            {  
                this.speechRecognizer.Recognizer.Grammars.Clear();  
      
                this.speechRecognizer.Recognizer.Grammars.AddGrammarFromPredefinedType("search", SpeechPredefinedGrammar.WebSearch);  
      
                await this.speechRecognizer.Recognizer.PreloadGrammarsAsync();  
      
                try  
                {  
                    // Use the built-in UI to prompt the user and get the result.  
                    SpeechRecognitionUIResult recognitionResult = await this.speechRecognizer.RecognizeWithUIAsync();  
      
                    if (recognitionResult.ResultStatus == SpeechRecognitionUIStatus.Succeeded)  
                    {  
                        // Output the speech recognition result.  
                        this.txtWebSearchResult.Text = "You said: " + recognitionResult.RecognitionResult.Text;  
                    }  
      
                }  
                catch (Exception ex)  
                {  
                    MessageBox.Show(ex.Message);  
                }  
            }  
        } 
