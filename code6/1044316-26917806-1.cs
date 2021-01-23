    class Program
    {
        private const int _kport = 54321;
        static void Main(string[] args)
        {
            SocketServer server = new SocketServer(_kport);
            Socket remote = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, _kport);
            remote.Connect(remoteEndPoint);
            using (NetworkStream stream = new NetworkStream(remote))
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                Task receiveTask = _Receive(reader);
                string text;
                Console.WriteLine("CLIENT: connected. Enter text to send...");
                while ((text = Console.ReadLine()) != "")
                {
                    writer.WriteLine(text);
                    writer.Flush();
                }
                remote.Shutdown(SocketShutdown.Send);
                receiveTask.Wait();
            }
            server.Stop();
        }
        private static async Task _Receive(StreamReader reader)
        {
            string receiveText;
            while ((receiveText = await reader.ReadLineAsync()) != null)
            {
                Console.WriteLine("CLIENT: received \"" + receiveText + "\"");
            }
            Console.WriteLine("CLIENT: end-of-stream");
        }
    }
