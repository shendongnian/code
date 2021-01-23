    public class Client
    {
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer; 
        private Thread thrMessaging;
        private string UserName = "UK";
        private byte Tries = 0;
        private bool Connected = false;
        public void Connect()
        {
            if (!Connected)
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                string User = localIPs[0].ToString();
                string ServIP = ServIP = "127.0.0.1";//change this to your server ip
                InitializeConnection(ServIP, User);
            }
            else
            {
                CloseConnection("Disconnected at user's request.");
            }
        }
        private void InitializeConnection(string ServIp, string User)
        {
            IPAddress ipAddr = IPAddress.Parse(ServIp);
            tcpServer = new TcpClient();
            try
            {
                tcpServer.Connect(ipAddr, 1986);//change that 1986 to your server port
            }
            catch 
            { 
            if (Connected) CloseConnection("");
            MessageBox.Show("Connecteing to " + ServIp + "\r\nServer is Down ... Try nomber " + Tries); return; 
            }
            Connected = true;
            UserName = User;
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(User);
            swSender.Flush();
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }
        private void ReceiveMessages()
        {
            srReceiver = new StreamReader(tcpServer.GetStream());
            string ConResponse = srReceiver.ReadLine();
            if (ConResponse[0] == '1')
            {
            }
            else
            {
                string Reason = "Not Connected: ";
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                return;
            }
            while (Connected)
            {
                try
                {
                    string NewMsg = srReceiver.ReadLine();
                    if (NewMsg != null && NewMsg != "")
                        PacketHandler.HandlePacket(NewMsg, this);
                                           
                }
                catch {  }
            }
        }
        public void CloseConnection(string Reason)
        {
            try
            {
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
            catch { }
        }
        public void SendMessage(string Msg)
        {
            if (Msg.Length >= 1)
            {
                try
                {
                    Tries++;
                    swSender.WriteLine(Msg);
                    swSender.Flush();
                    Tries = 0;
                }
                catch
                {
                    if (Tries < 5)
                    {
                        try
                        {
                            CloseConnection("No connection made");
                            Connect();
                        }
                        catch { }
                        SendMessage(Msg);
                    }
                    else { MessageBox.Show("Connecting to server faild for 5 tries"); Tries = 0; }
                }
            }
        }
