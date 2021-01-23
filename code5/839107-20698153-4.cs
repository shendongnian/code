    public sealed partial class Client : IDisposable
    {
        // Called by producers to send data over the socket.
        public void SendData(byte[] data)
        {
            _sender.SendData(data);
        }
    
        // Consumers register to receive data.
        public event EventHandler<DataReceivedEventArgs> DataReceived;
    
        public Client()
        {
            _client = new TcpClient(...);
            _stream = _client.GetStream();
    
            _receiver = new Receiver(_stream);
            _sender   = new Sender(_stream);
    
            _receiver.DataReceived += OnDataReceived;
        }
    
        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            var handler = DataReceived;
            if (handler != null) DataReceived(this, e);  // re-raise event
        }
    
        private TcpClient     _client;
        private NetworkStream _stream;
        private Receiver      _receiver;
        private Sender        _sender;
    }
