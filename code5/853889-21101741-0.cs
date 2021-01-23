    public void Timing()
    {
        // while (true) to simplify...
        // You should probably remember the last time sent and adjust the 40ms accordingly
        while (true)
        {
            SendPacketAsync(DateTime.UtcNow);
            Thread.Sleep(40);
        }
    }
    public Task SendPacketAsync(DateTime timing)
    {
        return Task.Factory.StartNew(() => {
            var packet = ...; // use timing
            packet.Send(); // abstracted away, probably IO blocking
        });
    }
