    private static NetMQContext _context = NetMQContext.Create();
    public static void Main(string[] args)
    {
        Thread publish1 = new Thread(() => Publish(5000));
        Thread publish2 = new Thread(() => Publish(5001));
        publish1.Start();
        publish2.Start();
        Subscribe();
    }
    private static void Publish(ushort port)
    {
        using (NetMQSocket socket = _context.CreatePublisherSocket())
        {
            socket.Bind("tcp://127.0.0.1:" + port);
            while (true)
            {
                socket.Send("Hello from " + port);
                Thread.Sleep(1000);
            }
        }
    }
    private static void Subscribe()
    {
        using (NetMQSocket socket = _context.CreateSubscriberSocket())
        {
            socket.Connect("tcp://127.0.0.1:5000");
            socket.Connect("tcp://127.0.0.1:5001");
            socket.Subscribe("");
            while (true)
            {
                Console.WriteLine(socket.ReceiveString());
            }
        }
    }
