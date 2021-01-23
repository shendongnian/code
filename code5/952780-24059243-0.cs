    async Task TestLogger(Device device, int seconds)
    {
        var writer = new StreamWriter("test.log");
        var batch = new BatchBlock<byte[]>(1000);
        var logAction = new ActionBlock<byte[][]>(
            bytes =>
            {
                var watch = Stopwatch.StartNew();
                foreach (var packet in bytes)
                {
                    writer.WriteLine(ToHexString(packet));
                    if (watch.Elapsed >= TimeSpan.FromSeconds(1))
                    {
                        return; // or throw new Exception("Write Time Out!");
                    }
                }
            });
        batch.LinkTo(logAction);
        logAction.Completion.ContinueWith(_ => writer.Dispose());
        while (true)
        {
            await batch.SendAsync(await device.ReadAsync());
        }
    }
