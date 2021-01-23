    private void button1_Click(object sender, EventArgs e)
        {
            SocketPermission socketPermission = new SocketPermission(NetworkAccess.Connect, TransportType.Tcp, "", SocketPermission.AllPorts);
            socketPermission.Demand();
            IPHostEntry ipHOst = Dns.GetHostEntry("");
            for (int i = 0; i < ipHOst.AddressList.Length; i++)
            {
                ipAddress = ipHOst.AddressList[i];
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(address), 4532);
                socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.NoDelay = false;
                try
                {
                    socket.Connect(ipEndPoint);
                    MessageBox.Show("Socket connected to " + socket.RemoteEndPoint.ToString());
                    break;
                }
                catch (Exception eX)
                {
                    MessageBox.Show(eX.Message);
                }
            }
            
        }
