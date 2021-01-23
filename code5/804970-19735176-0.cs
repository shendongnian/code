     public static void Main()
        {
            ConsoleKeyInfo cki;
    
            Console.Clear();
    
            // Establish an event handler to process key press events.
             Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
    
            while (true) {
                Console.Write("Press any key, or 'X' to quit, or ");
                Console.WriteLine("CTRL+C to interrupt the read operation:");
    
                // Start a console read operation. Do not display the input.
                cki = Console.ReadKey(true);
    
                // this process can be skipped 
                // Console.WriteLine("  Key pressed: {0}\n", cki.Key);
    
                // Exit if the user pressed the 'X' key. 
                if (cki.Key == ConsoleKey.F4) break;
           }
    }
    protected static void myHandler(object sender, ConsoleCancelEventArgs args)
    {
                args.Cancel = true;
                go_back_to_main();
     }
