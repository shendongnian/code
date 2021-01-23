    public partial class Login : Form
    {
        private ChatWindow cw;
        private Socket serverSocket;
        private List<Socket> socketList;
        private byte[] buffer;
        private bool isHost;
        private bool isClosing;
        private ListBox usernames;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            ipLabel.Text = getLocalIP();
            cw = new ChatWindow();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketList = new List<Socket>();
            buffer = new byte[1024];
            isClosing = false;
            usernames = new ListBox();
        }
        public string getLocalIP()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
        private void joinButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tryPort = 0;
                this.isHost = false;
                cw.callingForm = this;
                if (ipBox.Text == "" || portBox.Text == "" || nicknameBox.Text == "" || !int.TryParse(portBox.Text.ToString(), out tryPort))
                {
                    MessageBox.Show("You must enter an IP Address, Port, and Nickname to connect to a server.", "Missing Info");
                    return;
                }
                this.Hide();
                cw.Show();
                cw.connectTo(ipBox.Text, int.Parse(portBox.Text), nicknameBox.Text);
            }
            catch(Exception otheree) {
                MessageBox.Show("Error:\n\n" + otheree.ToString(),"Error connecting...");
                cw.Hide();
                this.Show();
            }
        }
        private void hostButton_Click(object sender, EventArgs e)
        {
            int tryPort = 0;
            if (portBox.Text == "" || nicknameBox.Text == "" || !int.TryParse(portBox.Text.ToString(), out tryPort)) {
                MessageBox.Show("You must enter a Port and Nickname to host a server.", "Missing Info");
                return;
            }
            startListening();
        }
        public void startListening()
        {
            try
            {
                this.isHost = true;                                                         //We're hosting this server
                cw.callingForm = this;                                                      //Give ChatForm the login form (this) [that acts as the server]
                cw.Show();                                                                  //Show ChatForm
                cw.isHost = true;                                                           //Tell ChatForm it is the host (for display purposes)
                this.Hide();                                                                //And hide the login form
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(portBox.Text)));  //Bind to our local address
                serverSocket.Listen(1);                                                     //And start listening
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);          //When someone connects, begin the async callback
                cw.connectTo("127.0.0.1", int.Parse(portBox.Text), nicknameBox.Text);       //And have ChatForm connect to the server
            }
            catch (Exception) {}
        }
        public void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                StateObject state = new StateObject();
                state.workSocket = serverSocket.EndAccept(AR);
                socketList.Add(state.workSocket);
                state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception) {}
        }
        public void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                if (isClosing)
                    return;
                StateObject state = (StateObject)AR.AsyncState;
                Socket s = state.workSocket;
                String content = "";
                int received = s.EndReceive(AR);
                if(received > 0)
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, received));
                content = state.sb.ToString();
                if (content.IndexOf(Environment.NewLine) > -1) //If we've received the end of the message
                {
                    if (content.StartsWith("!!addlist") && state.newConnection)
                    {
                        state.newConnection = false;
                        content = content.Replace("!!addlist", "");
                        string userNick = content.Trim();
                        if (isHost && userNick.StartsWith("!"))
                            userNick = userNick.Replace("!", "");
                        userNick = userNick.Trim();
                        if (userNick.StartsWith("!") || userNick == string.Empty || usernames.Items.IndexOf(userNick) > -1)
                        {
                            //Invalid Username :c get dropped
                            s.Send(Encoding.ASCII.GetBytes("Invalid Username/In Use - Sorry :("));
                            s.Shutdown(SocketShutdown.Both);
                            s.Disconnect(false);
                            s.Close();
                            socketList.Remove(s);
                            return;
                        }
                        usernames.Items.Add(userNick);
                        foreach (string name in usernames.Items)
                        {
                            if (name.IndexOf(userNick) < 0)
                            {
                                s.Send(Encoding.ASCII.GetBytes("!!addlist " + name + "\r\n"));
                                Thread.Sleep(10); //such a hack... ugh it annoys me that this works
                            }
                        }
                        foreach (Socket client in socketList)
                        {
                            try
                            {
                                if (client != s)
                                    client.Send(Encoding.ASCII.GetBytes("!!addlist " + userNick + "\r\n"));
                            }
                            catch (Exception) { }
                        }
                    }
                    else if (content.StartsWith("!!removelist") && !state.newConnection)
                    {
                        content = content.Replace("!!removelist", "");
                        string userNick = content.Trim();
                        usernames.Items.Remove(userNick);
                        foreach (Socket client in socketList)
                        {
                            try
                            {
                                if (client != s)
                                    client.Send(Encoding.ASCII.GetBytes("!!removelist " + userNick + "\r\n"));
                            }
                            catch (Exception) { }
                        }
                    }
                    else if (state.newConnection) //if they don't give their name and try to send data, just drop.
                    {
                        s.Shutdown(SocketShutdown.Both);
                        s.Disconnect(false);
                        s.Close();
                        socketList.Remove(s);
                        return;
                    }
                    else
                    {
                        foreach (Socket client in socketList)
                        {
                            try
                            {
                                if (client != s)
                                    client.Send(System.Text.Encoding.ASCII.GetBytes(content));
                            }
                            catch (Exception) { }
                        }
                    }
                }
                Array.Clear(state.buffer, 0, StateObject.BufferSize);
                state.sb.Clear();
                s.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception) {
                socketList.Remove(((StateObject)AR.AsyncState).workSocket);
            }
        }
        public void SendCallback(IAsyncResult AR)
        {
            try
            {
                StateObject state = (StateObject)AR.AsyncState;
                state.workSocket.EndSend(AR);
            }
            catch (Exception) {}
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.isClosing = true;
                if (this.isHost)
                {
                    foreach (Socket c in socketList)
                    {
                        if (c.Connected)
                        {
                            c.Close();
                        }
                    }
                    serverSocket.Shutdown(SocketShutdown.Both);
                    serverSocket.Close();
                    serverSocket = null;
                    serverSocket.Dispose();
                }
                socketList.Clear();
            }
            catch (Exception) { }
            finally
            {
                Application.Exit();
            }
        }
    }
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
        public bool newConnection = true;
    }
