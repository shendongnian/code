    static async Task test()
    {
        var transform = new TransformBlock<int, double>(i => i/2.0);
        var output    = new ActionBlock<double>(d => Console.WriteLine(d));
        // Warning CS4014 here:
        var continuation = transform.Completion.ContinueWith(_ => output.Complete());
        transform.LinkTo(output);
        for (int i = 0; i < 10; ++i)
            await transform.SendAsync(i);
        transform.Complete();
        await Task.WhenAll(continuation, output.Completion)
    }
