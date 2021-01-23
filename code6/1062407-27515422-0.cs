        public static SpeechRecognitionEngine sre;
        static void Main(string[] args)
        {
            sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            sre.LoadGrammar(new Grammar(new GrammarBuilder("exit")));
            sre.LoadGrammar(new DictationGrammar());
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
               
            Console.ReadLine();
        }
    
        private static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "exit")
            {
                sre.RecognizeAsyncStop();
            }
            Console.WriteLine("You said: " + e.Result.Text);
        }
