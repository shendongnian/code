    WeakReference weakTask = null;
    using (var cts = new CancellationTokenSource())
    {
      weakTask = Start(cts);
    }
    
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    
    Console.WriteLine(weakTask.IsAlive); // prints false
