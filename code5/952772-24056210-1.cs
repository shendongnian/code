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
        using (var writer = new StreamWriter("test.log")))
        {
            while (true)
            {
                Stopwatch watch = Stopwatch.StartNew();
                
                var batch = _data;
                _data = new List<byte[]>();
                foreach (var packet in batch)
                {
                    writer.WriteLine(ToHexString(packet));
                    
                    if (watch.Elapsed >= TimeSpan.FromSeconds(1))
                    {
                        throw new Exception("Write Time Out!");
                    }
                }
                
                await Task.Delay(TimeSpan.FromSeconds(1) - watch.Elapsed);
            }
        }
    }
