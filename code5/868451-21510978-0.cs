    void SendObject<T>(StreamWriter s, T o)
    {
        s.WriteLine( JsonConvert.SerializeObject(o) );
        s.Flush();
    }
    T ReadObject<T>(StreamReader r)
    {
        var line = r.ReadLine();
        if (line == null) return default(T);
        return JsonConvert.DeserializeObject<T>(line);
    }
---
    SemaphoreSlim serverReady = new SemaphoreSlim(0);
    //SERVER
    Task.Factory.StartNew(() =>
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8088);
            listener.Start();
            serverReady.Release();
            while(true)
            {
                var client = listener.AcceptTcpClient();
                Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Client connected...");
                        var reader = new StreamReader(client.GetStream());
                        var obj = ReadObject<string>( reader) ;
                        while(obj != null)
                        {
                            Console.WriteLine("[" + obj + "]");
                            obj = ReadObject<string>(reader);
                        }
                        Console.WriteLine("Client disconnected...");
                    });
            }
        });
    serverReady.Wait();
    //CLIENT
    Task.Factory.StartNew(() =>
    {
        TcpClient client = new TcpClient();
        client.Connect("localhost", 8088);
        var writer = new StreamWriter(client.GetStream());
        for (int i = 0; i < 10; i++)
        {
            SendObject(writer, "test\nmessage" + i); //message containing `\n` :)
        }
        client.Close();
    });
