    class Program
    {
        static byte[] buffer = new byte[10];
        static bool disc = false;
        static void Main(string[] args)
        {
            dbtest dt = new dbtest();
            dt.Disconnected += new EventHandler(dt_Disconnected);
            dt.Start("10.1.32.97", 1433);
            while (!Console.KeyAvailable)
            {
                Console.WriteLine(disc?"disconnected":"tick");
                Thread.Sleep(2000);
            }
            dt.Stop();
        }
        static void dt_Disconnected(object sender, EventArgs e)
        {
            disc = true;
            Console.WriteLine("Disconnected");
        }
    }
    public class dbtest
    {
        static byte[] buffer = new byte[10];
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public event EventHandler Disconnected = null;
        public void Start(string host, int port)
        {
            if(s!=null)
            {
                Stop();
            }
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(host, port);
            Console.WriteLine("Connected.");
            s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallBack, s);
        }
        public void Stop()
        {
            if (s != null)
            {
                s.Close();
                s.Dispose();
                s = null;
            }
        }
        void ReceiveCallBack(IAsyncResult ar)
        {
            Socket s = ar as Socket;
            if (s != null && s.Connected)
            {
                int rcvd = s.EndReceive(ar);
                if (rcvd > 0)
                {
                    s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallBack, s);
                    return;
                }
            }
            if(Disconnected!=null)
                Disconnected(this, EventArgs.Empty);
        }
    }
