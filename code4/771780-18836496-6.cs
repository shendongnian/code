    public class EasySocketListener : IDisposable
    {
        private Socket _socket;
        public void Start(int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
            _socket.Listen(1);
            StartAccepting();
        }
        private void StartAccepting()
        {
            try
            {
                _socket.BeginAccept((asyncResult) =>
                {
                    try
                    {
                        Socket clientSocket = _socket.EndAccept(asyncResult);
                        if (OnSocketAccept != null)
                            OnSocketAccept(this, new SocketEventArgs(clientSocket));
                        StartAccepting();
                    }
                    catch { }
                }, null);
            }
            catch { }
        }
        public void Dispose()
        {
            _socket.Dispose();
        }
        public event EventHandler<SocketEventArgs> OnSocketAccept;
    }
