    class Program
    {
        private static Task _tcpServerTask;
        private const int ServerPort = 1000;
        static void Main(string[] args)
        {
            StartTcpServer();
            KeepAlive();
            
            Console.ReadKey();
        }
        private static void StartTcpServer()
        {
            _tcpServerTask = new Task(() =>
            {
                var tcpListener = new TcpListener(IPAddress.Any, ServerPort);
                tcpListener.Start();
                var tcpClient = tcpListener.AcceptTcpClient();
                Console.WriteLine("Server got client ...");
                using (var stream = tcpClient.GetStream())
                {
                    const string message = "Stay alive!!!";
                    var arrayMessage = Encoding.UTF8.GetBytes(message);
                    stream.Write(arrayMessage, 0, arrayMessage.Length);   
                }
                tcpListener.Stop();
            });
            _tcpServerTask.Start();
        }
        private static void KeepAlive()
        {
            var tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", ServerPort);
            using (var stream = tcpClient.GetStream())
            {
                var buffer = new byte[16];
                while (stream.Read(buffer, 0, buffer.Length) != 0)
                    Console.WriteLine("Client received: {0} ", Encoding.UTF8.GetString(buffer));
            }
        }
    }
