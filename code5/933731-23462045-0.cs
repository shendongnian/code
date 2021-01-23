        public void Connect(IPAddress ipAddress, int port, double reconnectInterval)
        {
            _reconnectTimer = new Timer { Interval = _reconnectInterval, Enabled = false, AutoReset = false };
            _reconnectTimer.Elapsed += ReconnectTimer_Elapsed;
            _tcpClient = new TcpClient();
            try
            {
                _tcpClient.BeginConnect(ipAddress, port, ConnectionRequestCallback, null);
            }
            catch (Exception exception)
            {
                LostConnection(exception.Message);
            }
        }
