    filteredStream.StreamStopped += (sender, args) =>
    {
        Console.WriteLine(args.DisconnectMessage.Reason);
        if (args.Exception != null)
        {
            Console.WriteLine(args.Exception);
        }
    };
