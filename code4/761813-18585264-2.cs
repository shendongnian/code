    public class Listener
        {
            private TcpListener _listener;
            private TcpClient _client;
    
            public void Start()
            {
                _listener = new TcpListener(IPAddress.Loopback, 17999);
                _listener.Start();
                _listener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), _listener);
            }
    
            private void AcceptTcpClientCallback(IAsyncResult ar)
            {
                try
                {
                    Debug.WriteLine("Accepted tcp client callback");
                    _client = _listener.EndAcceptTcpClient(ar);               
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }            
            }
    
            public void Write(string data)
            {
                try
                {
                    NetworkStream ns = _client.GetStream();
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    ns.Write(buffer, 0, buffer.Length);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
    
        }
