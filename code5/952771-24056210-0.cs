    List<byte[]> _data = new List<byte[]>();
    async Task Producer(Device device)
    {
        while (true)
        {
            _data.Add(await device.ReadAsync());
        }
    }
    async Task Consumer(Device device)
    {
        while (true)
        {
            await Task.Delay(1000);
            var batch = _data;
            _data = new List<byte[]>();
            var cancellationTokenSource = new CancellationTokenSource(1000);
            
            using (var writer = new StreamWriter("test.log")))
            {
                foreach (var packet in batch)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        throw new Exception("Write Time Out!");
                    }
                    
                    writer.WriteLine(ToHexString(packet));
                }
            }
        }
    }
