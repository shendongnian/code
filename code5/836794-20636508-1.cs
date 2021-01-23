         public class Connection : IDisposable {
        private readonly Queue<DataPackage> messages = new Queue<DataPackage>();
        public object syncLock = new Object();
        public List<DataPackage> GetCurrentMessages() {
            Monitor.Enter(syncLock);
            var result = new List<DataPackage>();
            try {
                foreach (var item in messages) {
                    result.Add(item);
                }
                messages.Clear();
            } finally {
                Monitor.Exit(syncLock);
            }
            return result;
        }
        private TcpListener listener;
        private TcpClient tcpClient;
        private int bufferSize;
        private bool running;
        public void Init(int port, int size) {
            // not real thread safe here
            if (running) return;
            running = true;
            bufferSize = size;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            listener = new TcpListener(ipAddress, port);
            listener.Start();
            listener.BeginAcceptSocket(ar => { 
                tcpClient = listener.AcceptTcpClient();
                tcpClient.NoDelay = true;
                listener.EndAcceptTcpClient(ar);
                var t = new Thread(readEvent);
                t.Start();
            }, null);
        }
        private bool shouldRead = true;
        private void readEvent() {
            while (shouldRead) {
                byte[] bytes = new byte[bufferSize];
                try {
                    Console.Write("Wait...:");
                    var ip_client = tcpClient.Client.RemoteEndPoint.ToString();
                    var stream = tcpClient.GetStream();
                    DateTime startTime = DateTime.Now;
                    stream.Read(bytes, 0, bytes.Length);
                    DateTime endTime = DateTime.Now;
                    var package = new DataPackage(); // add your stuff in here
                    Monitor.Enter(syncLock);
                    try {
                        messages.Enqueue(package);
                    } finally {
                        Monitor.Exit(syncLock);
                    }
                    System.Console.Write("...received from " + ip_client + " busy:");
                    TimeSpan duration = endTime - startTime;
                    System.Console.WriteLine(duration.Seconds + "s");
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public class DataPackage {}
        #region IDisposable Members
        private bool disposed;
        void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    shouldRead = false;
                    tcpClient.Close();
                    listener.Stop();
                }
                //Clean up unmanaged resources
            }
            disposed = true;
        }
        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }
