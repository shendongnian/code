    async Task TestLogger(Device device, int seconds)
    {
        var writer = new StreamWriter("test.log");
        var batch = new BatchBlock<byte[]>(1000);
        ActionBlock<byte[][]> logAction;
        logAction = new ActionBlock<byte[][]>(
            bytes =>
            {
                foreach (var packet in bytes)
                {
                    if (logAction.InputCount > 0)
                    {
                        return; // or throw new Exception("Write Time Out!");
                    }
                    writer.WriteLine(ToHexString(packet));
                }
            });
        batch.LinkTo(logAction);
        logAction.Completion.ContinueWith(_ => writer.Dispose());
        while (true)
        {
            await batch.SendAsync(await device.ReadAsync());
        }
    }
