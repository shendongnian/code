    private static TcpListener listener = .....;
    private static bool listen = true; // <--- boolean flag to exit loop
    private static async Task HandleClient(TcpClient clt)
    {
        using NetworkStream ns = clt.GetStream();
        using StreamReader sr = new StreamReader(ns);
        string msg = await sr.ReadToEndAsync();
        Console.WriteLine("Received new message (" + msg.Length + " bytes):\n" + msg);
    }
    public static async void Main()
    {
        while (listen)
            if (listener.Pending())
                await HandleClient(await listener.AcceptTcpClientAsync());
            else
                await Task.Delay(100); //<--- timeout
    }
