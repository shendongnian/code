        static void Main()
        {
            var envVars = Environment.GetEnvironmentVariables();
            Parallel.ForEach( envVars.Cast<DictionaryEntry>(), ev =>
                {
                    Console.WriteLine( "{0}: {1}", ev.Key, ev.Value );
                } );
            Console.ReadLine();
        }
