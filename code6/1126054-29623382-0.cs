    var cts = new CancellationTokenSource();
    var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token);
    linkedCts.CancelAfter(1000);
    Thread.Sleep(2000);
    Console.WriteLine(linkedCts.IsCancellationRequested);
    Console.WriteLine(cts.IsCancellationRequested);
    cts.Cancel();
    Console.WriteLine(cts.IsCancellationRequested);
