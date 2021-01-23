    // Thread 1
    Console.WriteLine("Writing thread starting");
    ThreadSafe.Assign();
    Console.WriteLine("Writing thread done");
    // Thread 2
    Console.WriteLine("Reading thread starting");
    while (ThreadSafe._x != 123)
    {
        // Do nothing
    }
    Console.WriteLine("Reading thread done");
