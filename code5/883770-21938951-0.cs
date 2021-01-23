    var wr = CreateWeakReference();
    Console.WriteLine("object available: {0}", wr.Target != null);
    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
    GC.WaitForPendingFinalizers();
    Console.WriteLine("object garbage collected: {0}", wr.Target == null);
