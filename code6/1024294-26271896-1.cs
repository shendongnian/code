    var signal = new ManualResetEvent(false); // instantiate in "unsignaled" state
    new Thread (() =>
    {
        Console.WriteLine("Sending command to hardware controller...");
        // send your command
        // ...
        Console.WriteLine("Done.");
        signal.Set(); // signal the waiting thread that it can continue.
    }).Start();
    Console.WriteLine("Waiting for hardware thread to do it's work...");
    signal.WaitOne(); // block thread until we are signaled.
    signal.Dispose();
    Console.WriteLine("Got our signal! we can continue.");
