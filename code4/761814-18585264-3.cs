    public class Client
        {
            private TcpClient _client;
            private byte[] _buffer;
    
            public void Start()
            {
                try
                {
                    _client = new TcpClient();
                    _client.BeginConnect(IPAddress.Loopback, 17999, new AsyncCallback(ConnectCallback), _client);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
    
            private void ConnectCallback(IAsyncResult ar)
            {
                try
                {
                    NetworkStream ns = _client.GetStream();
                    _buffer = new byte[_client.ReceiveBufferSize];
                    ns.BeginRead(_buffer, 0, _buffer.Length, new AsyncCallback(ReadCallback), null);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
    
            private void ReadCallback(IAsyncResult ar)
            {
                try
                {
                    NetworkStream ns = _client.GetStream();
                    int read = ns.EndRead(ar);
                    string data = Encoding.ASCII.GetString(_buffer, 0, read);
    
                    var res = data.Split(new [] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    
                    foreach (var r in res)
                    {
                        Debug.WriteLine(r); // process messages
                    }
                    ns.BeginRead(_buffer, 0, _buffer.Length, ReadCallback, _client);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }            
            }
        }
