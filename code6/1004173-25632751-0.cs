        public class Connection
        {
            public string ip = "";
            public string port = "";
            public bool listening = false;
            public TcpClient tcpClient;
            private BackgroundWorker bw = new BackgroundWorker();
            private NetworkStream stream;
            public delegate DataReceivedEvent(Byte[] data, TcpEventArgs e);
            public DataReceivedEvent dataReceived;
            public List<Command> commands = new List<Command>();
            
            //for Debugging purpose
            public string lastError = "";
            
            public Connection(string ip, string port)
            {
                this.ip = ip;
                this.port = port;
                bw.WorkerSupportsCancellation = true;
                if(!Connect())
                {
                    return;
                    //maybe do something here?
                }                
            }
            
            public bool Connect()
            {
                try
                {
                    tcpClient.Connect(ip, port);
                    stream = tcpClient.GetStream();
                    return true;
                }
                catch(Exception ex)
                {
                    lastError = ex.Message + " - " + ex.StackTrace;
                    return false;
                }
            }
            
            public void BeginListening()
            {
                bw.DoWork += listenToNetwork();
                bw.RunWorkerAsync();
            }
            
            public void EndListening()
            {
                bw.CancelAsync();
            }
            
            private void listenToNetwork(Object sender, DoWorkEventArgs e)
            {
                while(!PendingCancellation)
                {
                    Byte[] bytes = new Byte[preferedLenghth];
                    listening = true;
                    Int32 bytesRead = stream.Read(bytes, 0, bytes.Length);
                    if(dataReceived != null)
                    {
                        dataReceived(bytes, new TcpEventArgs(bytesRead));
                    }
                }
                listening = false;
            }
            
            public void SendCommands()
            {
                foreach(Command cmd in commands)
                {
                    cmd.Execute(ref stream);
                }
            }
        }
 
