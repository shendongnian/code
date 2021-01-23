    var abc = new AsyncBlockingCollection<int>();
    var producer = Task.Run(async () =>
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(100);
            abc.Add(i);
        }
        abc.CompleteAdding();
    });
    var consumer = Task.Run(async () =>
    {
        await abc.GetConsumingEnumerable().ForEachAsync(async item =>
        {
            await Task.Delay(200);
            await Console.Out.WriteAsync(item + " ");
        });
    });
    await Task.WhenAll(producer, consumer);
