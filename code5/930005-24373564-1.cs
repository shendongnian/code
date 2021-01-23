    Stopwatch sw = new Stopwatch();
    sw.Start();
    
    using (TcpClient client = new TcpClient("www.google.com", 443))
    using (SslStream stream = new SslStream(client.GetStream(), true))
    {
    
        stream.AuthenticateAsClient("www.google.com");
    
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        {
            writer.AutoFlush = true;
    
            // Wait for your signal here
    
    
            writer.Write("GET /\r\n");
    
            string response = reader.ReadToEnd();
        }
    }
    
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
