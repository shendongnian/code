    class Server
    {
        int BUFSIZE = 100;
        int servPort = 1551;
        public static String ClientOrder = "";
        public static int bytesRcvd;
        public void RunServer()
        {
            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream netStream = null;
            listener = new TcpListener(IPAddress.Any, servPort);
            listener.Start();
            byte[] rcvBuffer = new byte[BUFSIZE];
            while (true)
            {
                client = listener.AcceptTcpClient(); // Get clien
                netStream = client.GetStream();
                {
                    rcvBuffer = new byte[BUFSIZE];
                    bytesRcvd = netStream.Read(rcvBuffer, 0, rcvBuffer.Length);
                    ClientOrder = (Encoding.ASCII.GetString(rcvBuffer)).Substring(0, bytesRcvd);
                    netStream.Close();
                    client.Close();
                }
            }
        }
    }
