    var parentCts = new CancellationTokenSource();
    var childCts = CancellationTokenSource.CreateLinkedTokenSource(parentCts.Token);
            
    childCts.CancelAfter(1000);
    Console.WriteLine("Cancel child CTS");
    Thread.Sleep(2000);
    Console.WriteLine("Child CTS: {0}", childCts.IsCancellationRequested);
    Console.WriteLine("Parent CTS: {0}", parentCts.IsCancellationRequested);
    Console.WriteLine();
            
    parentCts.Cancel();
    Console.WriteLine("Cancel parent CTS");
    Console.WriteLine("Child CTS: {0}", childCts.IsCancellationRequested);
    Console.WriteLine("Parent CTS: {0}", parentCts.IsCancellationRequested);
