    Console.WriteLine ("creating thread");
    Thread t = new Thread(() =>
    {
        Console.WriteLine ("executing ThreadProc");
        try {
            ThreadProc ();
        } finally {
            Console.WriteLine ("finished executing ThreadProc");
        }
    });
    t.IsBackground = true;
    t.Start();
    Console.WriteLine ("started thread");
