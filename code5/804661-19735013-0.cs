    static void Main(string[] args)
    {
        System.Console.TreatControlCAsInput = true;
        // start the server
        Server server = new Server();
        server.Start();
        // wait for Ctrl+C to terminate
        Console.WriteLine("Press Ctrl+C To Terminate");
        ConsoleKeyInfo cki;
        do
        {
            cki = Console.ReadKey();
        } while (((cki.Modifiers & ConsoleModifiers.Control) == 0) || (cki.Key != ConsoleKey.C));
        // stop the server
        server.Stop();
    }
