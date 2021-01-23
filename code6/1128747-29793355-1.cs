        public void BindIPAddress(string strIPAddr)
        {
            Socket sock = null;
            IPEndPoint ipe = null;
            NetworkInterface[] ni = null;
            try
            {
                ipe = new IPEndPoint(IPAddress.Parse(strIPAddr), 80);
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    // Assuming the WebService is connection oriented (TCP)
                // sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  // if it broadcasts UDP packets, use this line (UDP)
                ni = NetworkInterface.GetAllNetworkInterfaces();
                if (ni != null && ni.Length > 0)
                {
                    ni[0].EnableStaticIP(strIPAddr, "255.255.240.0", "10.0.0.1");
                    ni[0].EnableStaticDns(new string[2] { "10.0.0.2", "10.0.0.3" });
                    sock.Bind(ipe);
                    this.Socket = sock;
                    this.IpAddress = strIPAddr;
                }
                else
                    throw new Exception("Network interface could not be retrieved successfully!");
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
