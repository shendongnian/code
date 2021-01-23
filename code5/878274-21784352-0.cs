    class Program
    {
        Queue<Connection> queue = new Queue<Connection>();
        TcpListener listener;
        ManualResetEvent reset = new ManualResetEvent(true);
        static void Main(string[] args)
        {
            new Program().Start();
        }
        void Start()
        {
            new Thread(new ThreadStart(HandleConnection)).Start();
            
            while (true)
            {
                while (queue.Any())
                {
                    var connection = queue.Dequeue();
                    connection.DoStuff();
                    if(!connection.Finished)
                        queue.Enqueue(connection);
                }
                reset.WaitOne();
            }
        }
        static readonly byte[] CONNECTION_REFUSED = Encoding.ASCII.GetBytes("Cannot accept a connection right now.");
        static readonly int CONNECTION_REFUSED_LENGTH = CONNECTION_REFUSED.Length;
        void HandleConnection()
        {
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                
                if (queue.Count <= 10)
                {
                    queue.Enqueue(new Connection(client));
                }
                else
                {
                    client.GetStream().Write(CONNECTION_REFUSED, 0, CONNECTION_REFUSED_LENGTH);
                }
            }
        }
    }
    public sealed class Connection
    {
        readonly TcpClient client;
        readonly Stopwatch stopwatch = new Stopwatch();
        public Connection(TcpClient client)
        {
            this.client = client;
            stopwatch.Start();
        }
        public void DoStuff()
        {
            
        }
        public void Abort()
        {
            client.Close();
            completed = true;
        }
        bool completed;
        public bool Finished
        {
            get
            {
                return stopwatch.ElapsedMilliseconds > 30 * 1000 || completed;
            }
        }
    }
