    LocalPrintServer printServer = new LocalPrintServer();
    EnumeratedPrintQueueTypes[] filters = new EnumeratedPrintQueueTypes[] {
        EnumeratedPrintQueueTypes.Fax
    };
    PrintQueueCollection printQueuesOnLocalServer =
        printServer.GetPrintQueues(filters);
    
    foreach (PrintQueue printQueue in printQueuesOnLocalServer)
    {
        Console.WriteLine("Printer: {0}", printQueue.Name);
    }
    
    Console.ReadLine();
