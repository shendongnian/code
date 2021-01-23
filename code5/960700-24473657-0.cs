       private SpeechRecognitionEngine recEngine = 
                                    new SpeechRecognitionEngine("en-US");           
        public MainWindow()
        {
            InitializeComponent();
            Choices mychoices = new Choices();
            mychoices.Add(new string[] {"Ok", "Test", "Hello"});
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(mychoices);
            Grammar mygrammar = new Grammar(gb);
            recEngine.LoadGrammarAsync(mygrammar);          
            recEngine.SpeechRecognized += 
                               new EventHandler<SpeechRecognizedEventArgs>
                                              (recEngine_SpeechRecognized);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
