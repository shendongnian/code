    Task.Run(() =>
        {
            Thread.Sleep(1000);
            if (token.IsCancellationRequested)
                Console.WriteLine("Cancellation requested in Task {0}.",
                                    Task.CurrentId);
        }, token);
    cts.Cancel();
