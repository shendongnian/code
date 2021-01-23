    async Task TestLogger(Device device, int seconds)
    {
        var writer = new StreamWriter("test.log");
        var batch = new BatchBlock<byte[]>(1000);
        var logAction = new ActionBlock<byte[]>(
            packet =>
            {
                return writer.WriteLineAsync(ToHexString(packet));
            });
        ActionBlock<byte[]> transferAction;
        transferAction = new ActionBlock<byte[]>(
            bytes =>
            {
                foreach (var packet in bytes)
                {
                    if (transferAction.InputCount > 0)
                    {
                        return; // or throw new Exception("Write Time Out!");
                    }
                    logAction.Post(packet);
                }
            }
        );
        
        batch.LinkTo(logAction);
        logAction.Completion.ContinueWith(_ => writer.Dispose());
        while (true)
        {
            batch.Post(await device.ReadAsync());
        }
    }
