    public partial class MainWindow : Window
    {
        private TcpListener _server;
        private List<TcpClient> _connectedClients;
        public MainWindow()
        {
            InitializeComponent();
            _server = new TcpListener(IPAddress.Any, 3000);
            _connectedClients = new List<TcpClient>();
            _server.Start();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); //every 1 sec!
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void SendMessage(string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);
            foreach (var client in _connectedClients)
            {
                NetworkStream clientStream = client.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Tick");
            Title = "hello";
            if (_server.Pending())
            {
                _connectedClients.Add(_server.AcceptTcpClient());
            }
        }
    }
