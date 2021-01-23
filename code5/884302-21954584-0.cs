         public partial class MainWindow : Window
            {
        
                SpeechRecognitionEngine _recognizer;
                SpeechSynthesizer sre = new SpeechSynthesizer();
                int count = 1;
        
                public MainW
    
    indow()
            {
                InitializeComponent();
                Initialize();
            }
    
            private void Initialize()
            {
                try
                {
                    var culture = new CultureInfo("en-US");
                    _recognizer = new SpeechRecognitionEngine(culture);
                    _recognizer.SetInputToDefaultAudioDevice();
                    _recognizer.LoadGrammar(GetGrammer());
                    _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
    
                    _recognizer.RecognizeAsync(RecognizeMode.Multiple);
    
                    sre.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child);
                    sre.Rate = -2;
    
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.InnerException.Message);
                }
            }
    
            private static Grammar GetGrammer()
            {
    
                var choices = new Choices();
                choices.Add(File.ReadAllLines(@"Commands.txt"));
                choices.Add(Enum.GetNames(typeof(Keys)).ToArray());
    
                var grammer = new Grammar(new GrammarBuilder(choices));
    
                return grammer;
            }
    
            void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
    
                string speech = e.Result.Text;
    
                if (Enum.GetNames(typeof(Keys)).Contains(speech))
                {
                    try
                    {
                        SendKeys.SendWait("{" + speech + "}");
                    }
                    catch (ArgumentException)
                    {
    
                    }
                }
    
                switch (speech)
                {
                  
                    case "Hello":
                        sre.Speak("Goodmorning ");
                        break;
                     
                    case "Notepad":
                        System.Diagnostics.Process.Start("Notepad");
                        break;
                    case "Maximize":
                        this.WindowState = System.Windows.WindowState.Maximized;
                        break;
                    case "Minimize":
                        this.WindowState = System.Windows.WindowState.Minimized;
                        break;
                    case "Restore":
                        this.WindowState = System.Windows.WindowState.Normal;
                        break;
                    case "Close":
                        Close();
                        break;
                }
            }       
        }
