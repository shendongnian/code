    class Program
    {
        static void Main(string[] args)
        {
            _TestWithSocket();
            _TestWithTcpClient();
            try
            {
                _TestSOCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
        }
        private static void _TestSOCode()
        {
            using (var tcp = new TcpClient())
            {
                var c = tcp.BeginConnect(IPAddress.Parse("8.8.8.8"), 8080, null, null);
                var success = c.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                if (!success)
                {
                    Console.WriteLine("Before cleanup");
                    tcp.Close();
                    tcp.EndConnect(c);
                    Console.WriteLine("After cleanup");
                    throw new Exception("Failed to connect.");
                }
            }
        }
        private static void _TestWithTcpClient()
        {
            TcpClient client = new TcpClient();
            object o = new object();
            Console.WriteLine("connecting TcpClient...");
            client.BeginConnect("8.8.8.8", 8080, asyncResult =>
            {
                Console.WriteLine("connect completed");
                try
                {
                    client.EndConnect(asyncResult);
                    Console.WriteLine("client connected");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("client closed before connected: NullReferenceException");
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("client closed before connected: ObjectDisposedException");
                }
                lock (o) Monitor.Pulse(o);
            }, null);
            Thread.Sleep(1000);
            Stopwatch sw = Stopwatch.StartNew();
            client.Close();
            lock (o) Monitor.Wait(o);
            Console.WriteLine("close took {0:0.00} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine();
        }
        private static void _TestWithSocket()
        {
            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            object o = new object();
            Console.WriteLine("connecting Socket...");
            socket.BeginConnect("8.8.8.8", 8080, asyncResult =>
            {
                Console.WriteLine("connect completed");
                try
                {
                    socket.EndConnect(asyncResult);
                    Console.WriteLine("socket connected");
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("socket closed before connected");
                }
                lock (o) Monitor.Pulse(o);
            }, null);
            Thread.Sleep(1000);
            Stopwatch sw = Stopwatch.StartNew();
            socket.Close();
            lock (o) Monitor.Wait(o);
            Console.WriteLine("close took {0:0.00} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine();
        }
    }
