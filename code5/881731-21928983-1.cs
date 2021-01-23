     protected static System.Net.Sockets.TcpClient Connect(string Ip, int Onport)
        {
            //start connection
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            try
            {
                clientSocket.Connect(Ip, Onport);
            }
            catch
            {
                //clientSocket.Connect("LocalHost", Onport);
                throw;
            }
            return clientSocket;
        }
