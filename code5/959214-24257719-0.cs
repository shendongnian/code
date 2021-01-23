    class Program
    {
        static void Main(string[] args)
        {
            var server = new ChannelTcpListener();
            server.MessageReceived = OnServerReceivedMessage;
            server.Start(IPAddress.Any, 0);
    
            var client = new ChannelTcpClient<object>(new MicroMessageEncoder(new DataContractMessageSerializer()),
                new MicroMessageDecoder(new DataContractMessageSerializer()));
            client.ConnectAsync(IPAddress.Loopback, server.LocalPort).Wait();
            client.SendAsync(new FileStream("TextSample.txt", FileMode.Open)).Wait();
    
    
            Console.ReadLine();
        }
    
        private static void OnServerReceivedMessage(ITcpChannel channel, object message)
        {
            var file = (Stream) message;
            var reader = new StreamReader(file);
            var fileContents = reader.ReadToEnd();
            Console.WriteLine(fileContents);
        }
    }
