    using System.Diagnostics;
    using System.Globalization;
    using System.Speech.Recognition;
    using System.Windows;
    namespace SpeechTestApp
    {
        public partial class MainWindow : Window
        {
            private SpeechRecognitionEngine recognizer;
            public MainWindow()
            {
                InitializeComponent();
                // Create a SpeechRecognitionEngine object for the default recognizer in the en-US locale.
                this.recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));
                {
                    // Create a grammar for finding services in different cities.
                    Choices services = new Choices(new string[] { "restaurants", "hotels", "gas stations" });
                    Choices cities = new Choices(new string[] { "Seattle", "Boston", "Dallas" });
                    GrammarBuilder findServices = new GrammarBuilder("Find");
                    findServices.Append(services);
                    findServices.Append("near");
                    findServices.Append(cities);
                    // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
                    Grammar servicesGrammar = new Grammar(findServices);
                    recognizer.LoadGrammarAsync(servicesGrammar);
                    // Add a handler for the speech recognized event.
                    recognizer.SpeechRecognized += recognizer_SpeechRecognized;
                    recognizer.SpeechDetected += RecognizerOnSpeechDetected;
                    recognizer.SpeechHypothesized += RecognizerOnSpeechHypothesized;
                    recognizer.SpeechRecognitionRejected += RecognizerOnSpeechRecognitionRejected;
                    recognizer.AudioStateChanged += RecognizerOnAudioStateChanged;
                    recognizer.AudioSignalProblemOccurred += RecognizerOnAudioSignalProblemOccurred;
                    // Configure the input to the speech recognizer.
                    recognizer.SetInputToDefaultAudioDevice();
                    // Start asynchronous, continuous speech recognition.
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
            private void RecognizerOnAudioSignalProblemOccurred(object sender, AudioSignalProblemOccurredEventArgs audioSignalProblemOccurredEventArgs)
            {
                Debug.WriteLine(audioSignalProblemOccurredEventArgs.AudioSignalProblem.ToString());
            }
            private void RecognizerOnAudioStateChanged(object sender, AudioStateChangedEventArgs audioStateChangedEventArgs)
            {
                Debug.WriteLine(audioStateChangedEventArgs.AudioState.ToString());
            }
            private void RecognizerOnSpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs speechRecognitionRejectedEventArgs)
            {
                Debug.WriteLine("RecognizerOnSpeechRecognitionRejected: " + speechRecognitionRejectedEventArgs.Result.Text);
            }
            private void RecognizerOnSpeechHypothesized(object sender, SpeechHypothesizedEventArgs speechHypothesizedEventArgs)
            {
                Debug.WriteLine("Hypothesized: " + speechHypothesizedEventArgs.Result.Text);
                tb.Text = speechHypothesizedEventArgs.Result.Text;
            }
            private void RecognizerOnSpeechDetected(object sender, SpeechDetectedEventArgs e)
            {
                Debug.WriteLine("Detected position: " + e.AudioPosition);
            }
            private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                Debug.WriteLine("Recognized text: " + e.Result.Text);
                tb.Text = e.Result.Text;
            }
        }
    }
