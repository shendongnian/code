    public partial class ChatWindow : Form
    {
        private Socket clientSocket;
        private Thread chatThread;
        private string ipAddress;
        private int port;
        private bool isConnected;
        private string nickName;
        public bool isHost;
        public Login callingForm;
        private static object conLock = new object();
        public ChatWindow()
        {
            InitializeComponent();
            isConnected = false;
            isHost = false;
        }
        public string getIP() {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
        public void displayError(string err)
        {
            output(Environment.NewLine + Environment.NewLine + err + Environment.NewLine);
        }
        public void op(string s)
        {
            try
            {
                lock (conLock)
                {
                    chatBox.Text += s;
                }
            }
            catch (Exception) { }
        }
        public void connectTo(string ip, int p, string n) {
            try
            {
                this.Text = "Trying to connect to " + ip + ":" + p + "...";
                this.ipAddress = ip;
                this.port = p;
                this.nickName = n;
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                if (!isHost)
                {
                    op("Connecting to " + ipAddress + ":" + port + "...");
                }
                else
                {
                    output("Listening on " + getIP() + ":" + port + "...");
                }
                clientSocket.Connect(ipAddress, port);
                isConnected = true;
                if (!isHost)
                {
                    this.Text = "Connected to " + ipAddress + ":" + port + " - Nickname: " + nickName;
                    output("Connected!");
                }
                else
                {
                    this.Text = "Hosting on " + getIP() + ":" + port + " - Nickname: " + nickName;
                }
                chatThread = new Thread(new ThreadStart(getData));
                chatThread.Start();
                nickName = nickName.Replace(" ", "");
                nickName = nickName.Replace(":", "");
                if(nickName.StartsWith("!"))
                    nickName = nickName.Replace("!", "");
                namesBox.Items.Add(nickName);
                sendRaw("!!addlist " + nickName);
            }
            catch (ThreadAbortException)
            {
                //do nothing; probably closing chat window
            }
            catch (Exception e)
            {
                if (!isConnected)
                {
                    this.Hide();
                    callingForm.Show();
                    clearText();
                    MessageBox.Show("Error:\n\n" + e.ToString(), "Error connecting to remote host");
                }
            }
        }
        public void removeNick(string n)
        {
            if (namesBox.Items.Count <= 0)
                return;
            for (int x = namesBox.Items.Count - 1; x >= 0; --x)
                if (namesBox.Items[x].ToString().Contains(n))
                    namesBox.Items.RemoveAt(x);
        }
        public void clearText()
        {
            try
            {
                lock (conLock)
                {
                    chatBox.Text = "";
                }
            }
            catch (Exception) { }
        }
        public void addNick(string n)
        {
            if (n.Contains(" ")) //No Spaces... such a headache
                return;
            if (n.Contains(":"))
                return;
            bool shouldAdd = true;
            n = n.Trim();
            for (int x = namesBox.Items.Count - 1; x >= 0; --x)
                if (namesBox.Items[x].ToString().Contains(n))
                    shouldAdd = false;
            if (shouldAdd)
            {
                namesBox.Items.Add(n);
                output("Someone new joined the room: " + n);
                //sendRaw("!!addlist " + nickName);
            }
        }
        public void addNickNoMessage(string n)
        {
            if (n.Contains(" ")) //No Spaces... such a headache
                return;
            if (n.Contains(":"))
                return;
            bool shouldAdd = true;
            n = n.Trim();
            for (int x = namesBox.Items.Count - 1; x >= 0; --x)
                if (namesBox.Items[x].ToString().Contains(n))
                    shouldAdd = false;
            if (shouldAdd)
            {
                namesBox.Items.Add(n);
                //sendRaw("!!addlist " + nickName);
            }
        }
        public void getData()
        {
            try
            {
                byte[] buf = new byte[1024];
                string message = "";
                while(isConnected)
                {
                    Array.Clear(buf, 0, buf.Length);
                    message = "";
                    int gotData = clientSocket.Receive(buf, buf.Length, SocketFlags.None);
                    if (gotData == 0)
                        throw new Exception("I swear, this was working before but isn't anymore...");
                    message = Encoding.ASCII.GetString(buf);
                    if (message.StartsWith("!!addlist"))
                    {
                        message = message.Replace("!!addlist", "");
                        string userNick = message.Trim();
                        if(!namesBox.Items.Contains(userNick))
                        {
                            addNick(userNick);
                        }
                        continue;
                    }
                    else if (message.StartsWith("!!removelist"))
                    {
                        message = message.Replace("!!removelist", "");
                        string userNick = message.Trim();
                        removeNick(userNick);
                        output("Someone left the room: " + userNick);
                        continue;
                    }
                    output(message);
                }
            }
            catch (Exception)
            {
                isConnected = false;
                output(Environment.NewLine + "Connection to the server lost.");
            }
        }
        public void output(string s)
        {
            try
            {
                lock (conLock)
                {
                    chatBox.Text += s + Environment.NewLine;
                }
            }
            catch (Exception) { }
        }
        private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(isConnected)
                    sendRaw("!!removelist " + nickName);
                isConnected = false;
                clientSocket.Shutdown(SocketShutdown.Receive);
                if (chatThread.IsAlive)
                    chatThread.Abort();
                callingForm.Close();
            }
            catch (Exception) { }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if(isConnected)
                send(sendBox.Text);
        }
        private void sendBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isConnected)
                {
                    if (sendBox.Text != "")
                    {
                        send(sendBox.Text);
                        sendBox.SelectAll();
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                    }
                }
            }
        }
        private void send(string t) {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(nickName + ": " + t + "\r\n");
                clientSocket.Send(data);
                output(nickName + ": " + t);
            }
            catch (Exception e)
            {
                displayError(e.ToString());
            }
        }
        private void sendRaw(string t)
        {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(t + "\r\n");
                clientSocket.Send(data);
            }
            catch (Exception e)
            {
                displayError(e.ToString());
            }
        }
        private void chatBox_TextChanged(object sender, EventArgs e)
        {
            chatBox.SelectionStart = chatBox.Text.Length;
            chatBox.ScrollToCaret();
        }
        private void sendBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }
    }
