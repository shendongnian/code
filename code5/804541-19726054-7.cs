            static void Main(string[] args)
            {
                SetupPath(); // current process, soon to be deprecated
                using (REngine engine = REngine.CreateInstance("RDotNet"))
                {
                    engine.Initialize(); // required since v1.5
                    CharacterVector charVec = engine.CreateCharacterVector(new[] { 
                         "Hello, R world!, .NET speaking" });
                    engine.SetSymbol("greetings", charVec);
                    engine.Evaluate("str(greetings)"); // print out in the console
                    string[] a = engine.Evaluate("'Hi there .NET, from the R 
                                              engine'").AsCharacter().ToArray();
                    Console.WriteLine("R answered: '{0}'", a[0]);
                    Console.WriteLine("Press any key to exit the program");
                    Console.ReadKey();
                }
            }
    
