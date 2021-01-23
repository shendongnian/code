    private static void Ping(string address = "bing.com", int iterations = 4)
    {
        Ping ping = new Ping();
        var hostEntry = Dns.GetHostEntry(address);
        
        byte[] buffer = new byte[32];
        new Random().NextBytes(buffer);
        Console.WriteLine("Pinging {0} [{1}] with {2} bytes of data:", hostEntry.HostName, hostEntry.AddressList[0], buffer.Length);
        for (int i = 0; i < iterations; i++)
        {
            PingReply reply = ping.Send(address, 1000, buffer);    
            Console.WriteLine("Reply from {0}: bytes={1}, time={2}ms, TTL={3}", reply.Address, reply.Buffer.Length, reply.RoundtripTime, reply.Options.Ttl);
        }
    }
