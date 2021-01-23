    class Program
    {
        private static bool _userRequestedAbort = false;
        // Indicate whether asynchronous recognition is complete.
        static void Main(string[] args)
        {
            // Create an in-process speech recognizer.
            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US")))
            {
                // Create a grammar for choosing cities for a flight.
                Choices cities = new Choices(new string[] { "Los Angeles", "New York", "Chicago", "San Francisco", "Miami", "Dallas" });
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append("I want to fly from");
                gb.Append(cities);
                gb.Append("to");
                gb.Append(cities);
                // Construct a Grammar object and load it to the recognizer.
                Grammar cityChooser = new Grammar(gb);
                cityChooser.Name = ("City Chooser");
                recognizer.LoadGrammarAsync(cityChooser);
                bool completed = false;
                // Attach event handlers.
                recognizer.RecognizeCompleted += (o, e) =>
                {
                    if (e.Error != null)
                    {
                        Console.WriteLine( "Error occurred during recognition: {0}", e.Error);
                    }
                    else if (e.InitialSilenceTimeout)
                    {
                        Console.WriteLine("Detected silence");
                    }
                    else if (e.BabbleTimeout)
                    {
                        Console.WriteLine("Detected babbling");
                    }
                    else if (e.InputStreamEnded)
                    {
                        Console.WriteLine("Input stream ended early");
                    }
                    else if (e.Result != null)
                    {
                        Console.WriteLine("Grammar = {0}; Text = {1}; Confidence = {2}", e.Result.Grammar.Name, e.Result.Text, e.Result.Confidence);
                    }
                    else
                    {
                        Console.WriteLine("No result");
                    }
                    completed = true;
                };
                // Assign input to the recognizer and start an asynchronous
                // recognition operation.
                recognizer.SetInputToDefaultAudioDevice();
                Console.WriteLine("Starting asynchronous recognition...");
                recognizer.RecognizeAsync();
                // Wait for the operation to complete.
                while (!completed)
                {
                    if (_userRequestedAbort)
                    {
                        recognizer.RecognizeAsyncCancel();
                        break;
                    }
                    Thread.Sleep(333);
                }
                Console.WriteLine("Done.");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
