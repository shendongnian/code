    class Program
    {
        static void Main( string[] args )
        {
            Task.Factory.StartNew( () =>
                {
                    Console.WriteLine( "Before sleep" );
                    System.Threading.Thread.Sleep( 5000 );
                    Console.WriteLine( "After sleep" );
                }
                , TaskCreationOptions.LongRunning
                );
            // press a key prior to the 5 second sleep expiration to demonstrate early termination
            Console.ReadKey();
        }
    }
