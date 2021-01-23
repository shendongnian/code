    public class TcpManager
    {
        private TcpClient _tcpClient;
        public TcpManager()
        {
            _tcpClient = new TcpClient(AddressFamily.InterNetwork);
            Task.Run(() => ConnectAsync());
        }
        private async Task ConnectAsync()
        {
            while (true)
            {
                if (!_tcpClient.Connected)
                {
                    Console.WriteLine("Connecting...");
                    try
                    {
                        _tcpClient = new TcpClient(AddressFamily.InterNetwork);
                        await _tcpClient.ConnectAsync(IPAddress.Parse(IP), Convert.ToInt16(PORT));
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    Console.WriteLine("Already Connected");
                }
            }
        }
        private void Close()
        {
            try
            {
                _tcpClient.Close();
                _tcpClient = new TcpClient(AddressFamily.InterNetwork);
                Console.WriteLine("Disconnected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
