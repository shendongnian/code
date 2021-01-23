    namespace Alexis
    {
        public partial class frmMain : Form
        {
            SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
            SpeechSynthesizer Alexis = new SpeechSynthesizer();
            SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
            DateTime timenow = DateTime.Now;
        }
      
      
      //other coding such as InitializeComponent and others.
      // 
      //
      //
      //
      
           private void frmMain_Load(object sender, EventArgs e)
            {
                _recognizer.SetInputToDefaultAudioDevice();
                _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"Default Commands.txt")))));
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Shell_SpeechRecognized);
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Social_SpeechRecognized);
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Web_SpeechRecognized);
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(AlarmClock_SpeechRecognized);
                _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(AlarmAM))));
                _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(AlarmPM))));
                _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechDetected);
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                startlistening.SetInputToDefaultAudioDevice();
                startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("alexis"))));
                startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
              
              //other stuff here..... Then once you have this then you can generate a method then with your code as follows
              //
              //
              //
              
              
              
               private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
                  {
                      int ranNum;
                      string speech = e.Result.Text;
                      switch (speech)
                      {
                          #region Greetings
                          case "hello":
                          case "hello alexis":
                              timenow = DateTime.Now;
                              if (timenow.Hour >= 5 && timenow.Hour < 12)
                              { Alexis.SpeakAsync("Goodmorning " + Settings.Default.User); }
                              if (timenow.Hour >= 12 && timenow.Hour < 18)
                              { Alexis.SpeakAsync("Good afternoon " + Settings.Default.User); }
                              if (timenow.Hour >= 18 && timenow.Hour < 24)
                              { Alexis.SpeakAsync("Good evening " + Settings.Default.User); }
                              if (timenow.Hour < 5)
                              { Alexis.SpeakAsync("Hello " + Settings.Default.User + ", it's getting late"); }
                              break;
                          case "whats my name":
                          case "what is my name":
                              Alexis.SpeakAsync(Settings.Default.User);
                              break;
                          case "stop talking":
                          case "quit talking":
                              Alexis.SpeakAsyncCancelAll();
                              ranNum = rnd.Next(1, 2);
                              if (ranNum == 2)
                              { Alexis.Speak("sorry " + Settings.Default.User); }
                              break;
                        }
                    }
              
              
