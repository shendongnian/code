    namespace Tcp_Server
    {
        public partial class Form1 : Form
        {
            delegate void AddTextCallback(string text);
            public Form1()
            {
                InitializeComponent();
            }
            private void btnStartServer_Click(object sender, EventArgs e)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ServerHandler));
            }
            private void ServerHandler(object args)
            {
                TcpListener _listner = new TcpListener(IPAddress.Parse("127.0.0.1"), 7777);
                // Start The Listner:
                _listner.Start();
                //Show the server is now listening (Note: UI Thread-Safe is required):
                AddText("Server started - Listening on port 7777");
                //Create a socket to accept - This is a Blocking Call:
                Socket _sock = _listner.AcceptSocket();
                //When Client Connects show server has accepted the socket:
                AddText("User from IP " + _sock.RemoteEndPoint);
                while (_sock.Connected)
                {
                    // Create Byte to Receive Data:
                    byte[] _Buffer = new byte[1024];
                    // Create integer to hold how large the Data Received is:
                    int _DataReceived = _sock.Receive(_Buffer);
                    if (_DataReceived == 0)
                    {
                        // Socket has been shutdown by the client.
                        break;
                    }
                    // Lets Server Know Message is Received:
                    AddText("Message Received...");
                    // Convert Buffer to a String:
                    string _Message = Encoding.ASCII.GetString(_Buffer);
                    // Post Message to the Server Window:
                    AddText(_Message);
                }
                _sock.Close();
                //When Client disconnect from the server:
                AddText("Client Disconnected.");
                _listner.Stop();
                AddText("Server Stop.");
            }
            private void AddText(string text)
            {
                // InvokeRequired required compares the thread ID of the 
                // calling thread to the thread ID of the creating thread. 
                // If these threads are different, it returns true. 
                if (this.listStatus.InvokeRequired)
                {
                    AddTextCallback d = new AddTextCallback(AddText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.listStatus.Items.Add(text);
                }
            }
        }
    }
