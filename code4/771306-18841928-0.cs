        static void Main(string[] args)
        {
            Choices gb = new Choices();
            gb.Add("encrypt the document");
            gb.Add("decrypt the document");
            Grammar commands = new Grammar(gb);
            commands.Name = "commands";
            DictationGrammar dg = new DictationGrammar("grammar:dictation#pronunciation");
            dg.Name = "Random";
            using (SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine(new CultureInfo("en-US")))
            {
            recoEngine.SetInputToDefaultAudioDevice();
            recoEngine.LoadGrammar(commands);
            recoEngine.LoadGrammar(dg);
            recoEngine.RecognizeCompleted += recoEngine_RecognizeCompleted;
            recoEngine.RecognizeAsync();
            System.Console.ReadKey(true);
            recoEngine.RecognizeAsyncStop();
            }
        }
        static void recoEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Result.Grammar.Name != "Random")
            {
                System.Console.WriteLine(e.Result.Text);
            }
        }
